    using System;
    using System.Windows.Forms;
    using System.Xml;
    using System.Net;
    using System.IO;
    using System.Diagnostics;
    
    namespace SAM
    {
    
        public partial class UpdateCheck : DevExpress.XtraEditors.XtraForm
        {
            public UpdateCheck()
            {
                InitializeComponent();
                lblCurrentVersion.Text = "Current Version:  " + Application.ProductVersion;
            }
    
            private void MainForm_Shown(object sender, EventArgs e)
            {
                BringToFront();
            }
    
            public static string GetWebPage(string URL)
            {
                System.Net.HttpWebRequest Request = (HttpWebRequest)(WebRequest.Create(new Uri(URL)));
                Request.Method = "GET";
                Request.MaximumAutomaticRedirections = 4;
                Request.MaximumResponseHeadersLength = 4;
                Request.ContentLength = 0;
    
                StreamReader ReadStream = null;
                HttpWebResponse Response = null;
                string ResponseText = string.Empty;
    
                try
                {
                    Response = (HttpWebResponse)(Request.GetResponse());
                    Stream ReceiveStream = Response.GetResponseStream();
                    ReadStream = new StreamReader(ReceiveStream, System.Text.Encoding.UTF8);
                    ResponseText = ReadStream.ReadToEnd();
                    Response.Close();
                    ReadStream.Close();
    
                }
                catch (Exception ex)
                {
                    ResponseText = string.Empty;
                }
    
                return ResponseText;
            }
    
            private void BtnChkUpdate_Click(object sender, EventArgs e)
            {
                System.Xml.XmlDocument VersionInfo = new System.Xml.XmlDocument();
                VersionInfo.LoadXml(GetWebPage("http://www.crimson-downloads.com/SAM/UpdateCheck.xml"));
    
                lblUpdateVersion.Text = "Latest Version:  " + (VersionInfo.SelectSingleNode("//latestversion").InnerText);
    
                textDescription.Text = VersionInfo.SelectSingleNode("//description").InnerText;
     
            }
    
            private void simpleButton2_Click(object sender, EventArgs e)
            {
                Process process = new Process();
                // Configure the process using the StartInfo properties.
                process.StartInfo.FileName = "http://www.crimson-downloads.com/SAM/Refresh.htm";
                process.StartInfo.Arguments = "-n";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                process.Start();
            }
        }
    }
