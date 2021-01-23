    System.Web.Mail.MailMessage message=new System.Web.Mail.MailMessage();
    message.From="from e-mail";
    message.To="to e-mail";
    message.Subject="Message Subject";
    message.Body="Message Body";
    System.Web.Mail.SmtpMail.SmtpServer="SMTP Server Address";
    System.Web.Mail.SmtpMail.Send(message);
