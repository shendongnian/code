    MailMessage mess = 
        new MailMessage(
            SPContext.Current.Site.WebApplication.OutboundMailReplyToAddress, 
            sendTo, 
            subject, 
            message);  
    mess.IsBodyHtml = true;  
    SmtpClient smtp = 
        new SmtpClient(
            SPContext.Current.Site.WebApplication.OutboundMailServiceInstance.Server.Address);  
    smtp.Send(mess);
