          public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(textBox1.Text);
            httpReq.AllowAutoRedirect = false;
            
          
                HttpWebResponse httpRes = (HttpWebResponse)httpReq.GetResponse();
            
                if (httpRes.StatusCode == HttpStatusCode.OK || httpRes.StatusCode==HttpStatusCode.Found)
                {
                    MessageBox.Show("It works.");
                }
                else
                {
                    MessageBox.Show("Not able to ping");
                }
                httpRes.Close();
           }
