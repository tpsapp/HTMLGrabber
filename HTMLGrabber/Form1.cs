using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace SocketTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void getPage_Click(object sender, EventArgs e)
        {
            if (urlInput.Text != "")
            {
                dataOuput.Clear();
                this.Text += " - " + urlInput.Text;
                //dataOuput.AppendText("Getting URL: " + urlInput.Text + "\n");
                WebResponse dataResponse;
                StreamReader readResponse;
                string result, url;
                if (!urlInput.Text.Contains("http://"))
                {
                    url = "http://" + urlInput.Text;
                }
                else
                {
                    url = urlInput.Text;
                }
                try
                {
                    HttpWebRequest getData = (HttpWebRequest)WebRequest.Create(url);
                    getData.Method = "GET";
                    //getData.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.2.8) Gecko/20100722 Firefox/3.6.8 GTB7.1";
                    getData.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US) AppleWebKit/532.0 (KHTML, like Gecko) Chrome/3.0.195.27 Safari/532.0 EVE-IGB";
                    dataResponse = getData.GetResponse();
                    readResponse = new StreamReader(dataResponse.GetResponseStream(), Encoding.UTF8);
                    result = readResponse.ReadToEnd();
                    dataOuput.AppendText(result);
                    if (readResponse != null)
                    {
                        readResponse.Close();
                    }
                    if (dataResponse != null)
                    {
                        dataResponse.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //throw;
                }
            }
            else
            {
                MessageBox.Show("Please enter a URL in the box to the left.");
            }
        }

        private void urlInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void urlInput_Enter(object sender, EventArgs e)
        {
            urlInput.SelectAll();
        }

        private void urlInput_MouseClick(object sender, MouseEventArgs e)
        {
            urlInput.SelectAll();
        }
    }
}
