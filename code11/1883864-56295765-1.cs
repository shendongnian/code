    void sendMail(IdentityMessage message)
    {
        MailMessage msg = new MailMessage();
        msg.From = new MailAddress(ConfigurationManager.AppSettings["Email"].ToString());
        msg.To.Add(new MailAddress(message.Destination));
        msg.IsBodyHtml = true;
        msg.Body = message.Body;
        msg.Subject = message.Subject;
        SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com", Convert.ToInt32(587));
        System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Email"].ToString(), ConfigurationManager.AppSettings["Password"].ToString());
        smtpClient.Credentials = credentials;
        smtpClient.EnableSsl = true;
        smtpClient.Send(msg);
    }
