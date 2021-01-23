    MailMessage message = new MailMessage();
            
            for (int i = 0; i < count; i++)
            {
                message.To.Add("email");
            }
    SmtpClient client = new SmtpClient();
    client.Send(message);
