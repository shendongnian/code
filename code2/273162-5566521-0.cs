     public static string sendMail(string to, string title, string subject, string body)
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    if (to == "")
                        to = "aevalencia119@gmail.com";
                    MailAddressCollection m = new MailAddressCollection();
                    m.Add(to);
                    mail.Subject = subject;
                    mail.From = new MailAddress( "aevalencia119@gmail.com");
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                    mail.ReplyTo = new MailAddress("aevalencia119@gmail.com");
                    mail.To.Add(m[0]);
                    smtp.Host = "smtp.gmail.com";
                     client.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new System.Net.NetworkCredential("aevalencia119@gmail.com", "####");
                    ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; }; 
    
                    smtp.Send(mail);
    
                    return "done";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
