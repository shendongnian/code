    private void SendEmail()
    {
       string emailPath = "../EmailTemplate.htm"; //Define your template path here
       string emailBody = string.Empty;
    
       StreamReader sr = new StreamReader(emailPath);
    
       emailBody = sr.ReadToEnd();
       sr.Close();
       sr.Dispose();
    
       //Send Email; you can refactor this out
       MailMessage message = new MailMessage();
       
       MailAddress address = new MailAddress("sender@domain.com", "display name");
    
       message.From = address;
       message.To.Add("to@domain.com");
       message.Subject = "Your Subject";
       message.IsBodyHtml = true; //defines that your email is in Html form
       message.Body = emailBody;
    
       //smtp is defined in web.config
       SmtpClient smtp = new SmtpClient();
       
       try
       {
          smtp.Send(message);
       }
       catch (Exception ex)
       {
          //catch errors here...
       }
    }
