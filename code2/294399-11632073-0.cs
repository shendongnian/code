    build with vs 2012 premium RC (july 2012)
    (click on label, not button)
    code :
    using System;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Net;
    using System.IO;
    using System.Collections.Generic;
    namespace getweather
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            } 
             private void button2_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }
            private void CYYY_Click(object sender, EventArgs e)
            {
                WebClient request = new WebClient();
                string url = "ftp://tgftp.nws.noaa.gov/data/observations/metar/decoded/CYYY.TXT";
                request.Credentials = new NetworkCredential("anonymous", "anonymous@example.com");
                byte[] newFileData = request.DownloadData(url);
                string fileString = System.Text.Encoding.UTF8.GetString(newFileData);
                richTextBox1.Text = fileString;
            }
            private void CYSC_Click(object sender, EventArgs e)
            {
                WebClient request = new WebClient();
                string url = "ftp://tgftp.nws.noaa.gov/data/observations/metar/decoded/CYSC.TXT";
                request.Credentials = new NetworkCredential("anonymous", "anonymous@example.com");
                byte[] newFileData = request.DownloadData(url);
                string fileString = System.Text.Encoding.UTF8.GetString(newFileData);
                richTextBox1.Text = fileString;
            }
            private void CYQB_Click(object sender, EventArgs e)
            {
                WebClient request = new WebClient();
                string url = "ftp://tgftp.nws.noaa.gov/data/observations/metar/decoded/CYQB.TXT";
                request.Credentials = new NetworkCredential("anonymous", "anonymous@example.com");
                byte[] newFileData = request.DownloadData(url);
                string fileString = System.Text.Encoding.UTF8.GetString(newFileData);
                richTextBox1.Text = fileString;
            }
            private void CYUY_Click(object sender, EventArgs e)
            {
                WebClient request = new WebClient();
                string url = "ftp://tgftp.nws.noaa.gov/data/observations/metar/decoded/CYUY.TXT";
                request.Credentials = new NetworkCredential("anonymous", "anonymous@example.com");
                byte[] newFileData = request.DownloadData(url);
                string fileString = System.Text.Encoding.UTF8.GetString(newFileData);
                richTextBox1.Text = fileString;
            }
            private void CYHU_Click(object sender, EventArgs e)
            {
                WebClient request = new WebClient();
                string url = "ftp://tgftp.nws.noaa.gov/data/observations/metar/decoded/CYHU.TXT";
                request.Credentials = new NetworkCredential("anonymous", "anonymous@example.com");
                byte[] newFileData = request.DownloadData(url);
                string fileString = System.Text.Encoding.UTF8.GetString(newFileData);
                richTextBox1.Text = fileString;
            }
        }
    }
