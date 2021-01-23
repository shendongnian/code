    var smtpClient = new SmtpClient("smtp.gmail.com",587);
    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
    smtpClient.EnableSsl = true;
    smtpClient.UseDefaultCredentials = false;
    smtpClient.Credentials = new NetworkCredential("USERNAME@gmail.com"
				,"PASSWORD");
    using (MailMessage message = new MailMessage("USERNAME@gmail.com","USERNAME@gmail.com"))
    {
        message.Subject = "test";
        smtpClient.Send(message);
    }
    using (MailMessage message = new MailMessage("USERNAME@gmail.com","USERNAME@gmail.com"))
    {
        message.Subject = "Re: test";
        message.Headers.Add("In-Reply-To", "<MESSAGEID.From.Original.Message>");
        message.Headers.Add("References",  "<MESSAGEID.From.Original.Message>");
        smtpClient.Send(message);
    }
