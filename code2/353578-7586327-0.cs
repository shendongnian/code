    MailMessage nMsg = new MailMessage();
    
    nMsg.From = new MailAddress(fromAddress);
    nMsg.Subject = subject;
    
    Attachment attachFile = new Attachment("Your file path here");
    nMsg.Attachments.Add(attachFile);
    
    SmtpClient mailer = new SmtpClient("yousmtpserver");
    mailer.Send(nMsg);
