    using (var mailer = new SmtpClient(host, port))
    {
        using (var message = new MailMessage(sender, recipient, subject, body) { IsBodyHtml = false })
        {
            mailer.UseDefaultCredentials = false;
            mailer.Credentials = new NetworkCredential(user, pass);
            mailer.EnableSsl = useSSL;
            mailer.Timeout = Timeout;
            mailer.Send(message);
        }
    }
