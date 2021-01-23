      try
            {
                using (SmtpClient client = new SmtpClient("smtpout.secureserver.net"))
                {
                    client.Credentials = new NetworkCredential("godaddyemail", "pw");
                    //client.Credentials = CredentialCache.DefaultNetworkCredentials; 
                    //client.DeliveryMethod = SmtpDeliveryMethod.Network; 
                    string to = "send email to who";
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                    mail.From = new MailAddress("mygodaddyemail", "subject");
                    mail.To.Add(to);
                    mail.Subject = "New member Alert";
                    mail.Body = "New member ";
                    mail.IsBodyHtml = true;
                    client.Send(mail);
                    return "sent mail";
                }
            }
            catch (Exception ex)
            {
                // exception handling 
                return ex.ToString();
            } 
