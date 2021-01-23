        private void Form1_Load(System.Object sender, System.EventArgs e)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
            using (System.Net.Mail.SmtpClient S = new System.Net.Mail.SmtpClient("smtp.gmail.com"))
            {
                S.EnableSsl = true;
                using (System.Net.Mail.MailMessage M = new System.Net.Mail.MailMessage("test@example.com", "test@example.com", "Test", "Test"))
                {
                    try
                    {
                        S.Send(M);
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
            }
        }
        private bool RemoteServerCertificateValidationCallback(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            Console.WriteLine(certificate);
            return true;
        }
