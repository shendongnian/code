    MailMessage msg = new MailMessage("from", "to", "subject", "body text");
    SmtpClient client = new SmtpClient("smtp server");
    System.Net.NetworkCredential cred = new System.Net.NetworkCredential("user", "password");
    client.UseDefaultCredentials = false;
    client.Credentials = cred;
    Client.Send(msg);
