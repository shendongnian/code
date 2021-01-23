    MailMessage emailmsg = new MailMessage("from@address.co.za", to@address.co.za)
    emailmsg.Subject = "Subject";
    emailmsg.IsBodyHtml = false;
    emailmsg.ReplyToList.Add("from@address.co.za");
    emailmsg.BodyEncoding = System.Text.Encoding.UTF8;
    emailmsg.HeadersEncoding = System.Text.Encoding.UTF8;
    emailmsg.SubjectEncoding = System.Text.Encoding.UTF8;
    emailmsg.Body = null;
    
    var plainView = AlternateView.CreateAlternateViewFromString(EmailBody, emailmsg.BodyEncoding, "text/plain");
    plainView.TransferEncoding = TransferEncoding.SevenBit;
    emailmsg.AlternateViews.Add(plainView);
    SmtpClient sSmtp = new SmtpClient();
    sSmtp.Send(emailmsg);
