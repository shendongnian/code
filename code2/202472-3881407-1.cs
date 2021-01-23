    using (var db = new mailingListClassDataContext())
    {
        var recipients = from e in db.mailinglistMembers
                         select e.email;
    
        SendMail("me@example.com", recipients);
    }
    
    public static void SendMail(string sender, string[] recipients)
    {
        var client = new System.Net.Mail.SmtpClient("127.0.0.1", 25);
    
        foreach (string recipient in recipients)
        {
            var message = new System.Net.Mail.MailMessage(sender, recipient);
            message.Subject = "Hello World!";
            message.Body = "<h1>Foo bar</h1>";
            message.IsBodyHtml = true;
            client.Send(message);
        }
    }
