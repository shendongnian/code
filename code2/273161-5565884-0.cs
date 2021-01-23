    MailMessage msgMail = new MailMessage("a@gmail.com", "b@mail.me", "subject", "message body");
    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
    smtp.EnableSsl = true;
    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
    smtp.Credentials = new System.Net.NetworkCredential("a@gmail.com", "a");
    try
    {
       smtp.Send(msgMail);
    }
    catch (Exception ex)
    {
    }
