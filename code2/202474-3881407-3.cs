    using (var db = new mailingListClassDataContext())
    {
        var client = new System.Net.Mail.SmtpClient();
    
        var recipients = from e in db.mailinglistMembers
                         select e.email;
    
        foreach (string recipient in recipients)
        {
            var message = new System.Net.Mail.MailMessage("sender@example.com", recipient);
            message.Subject = "Hello World!";
            message.Body = "<h1>Foo bar</h1>";
            message.IsBodyHtml = true;
            client.Send(message);
        }
    }
