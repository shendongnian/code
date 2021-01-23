            System.Net.Mail.MailMessage mail = null;
            System.Net.Mail.SmtpClient smtp = null;
            mail = new System.Net.Mail.MailMessage();
            //set the addresses
            mail.From = new System.Net.Mail.MailAddress(System.Configuration.ConfigurationManager.AppSettings["Email1"]);
            mail.To.Add("someone@example.com");
            mail.Subject = "The secret to the universe";
            mail.Body = "42";
            //send the message
            smtp = new System.Net.Mail.SmtpClient(System.Configuration.ConfigurationManager.AppSettings["YourSMTPServer"]);
            //to authenticate, set the username and password properites on the SmtpClient
            smtp.Credentials = new System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["EmailUsername1"], System.Configuration.ConfigurationManager.AppSettings["EmailPassword1"]);
            smtp.UseDefaultCredentials = false;
            smtp.Port = System.Configuration.ConfigurationManager.AppSettings["EmailSMTPPort"];
            smtp.EnableSsl = false;
            smtp.Send(mail);
