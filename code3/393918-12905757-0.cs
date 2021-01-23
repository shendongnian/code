      string username = ConfigurationManager.AppSettings["AWSSMTPUser"];
      string password = ConfigurationManager.AppSettings["AWSSMTPPass"];
                
      SmtpClient smtp = new SmtpClient();
      smtp.Host = "email-smtp.us-east-1.amazonaws.com";
      smtp.Port = 587;
      smtp.UseDefaultCredentials = false;
      smtp.Credentials = new NetworkCredential(username, password);
      smtp.EnableSsl = true;
      smtp.Send(mail);
