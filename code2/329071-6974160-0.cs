    using (var client = new SmtpClient("smtp.gmail.com", 587))
    {
        client.EnableSsl = true;
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential("username", "password");
        var message = new MailMessage(
            "sender@gmail.com", 
            "recipient@domain.com", 
            "some subject", 
            "mail body"
        );
        client.Send(message);
    }
