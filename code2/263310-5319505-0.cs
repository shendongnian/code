    public void Send(string from, string to,string smtpServer, int smtpPort,string username, string password)
            {
                try
                {
                    using (MailMessage mm = new MailMessage())
                    {
                        SmtpClient sc = new SmtpClient();
                        mm.From = new MailAddress(from, "Test");
                        mm.To.Add(new MailAddress(to));
                        mm.IsBodyHtml = true;
                        mm.Subject = "Test Message";
                        mm.Body = "This is a test email message from csharp";
                        mm.BodyEncoding = System.Text.Encoding.UTF8;
                        mm.SubjectEncoding = System.Text.Encoding.UTF8;
                        NetworkCredential su = new NetworkCredential(username, password);
                        sc.Host = smtpServer;
                        sc.Port = smtpPort;
                        sc.Credentials = su;
                        sc.Send(mm);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
