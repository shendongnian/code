    System.Net.Mail.MailMessage MyMessage = new System.Net.Mail.MailMessage();
    MyMessage.From = new MailAddress(“EmailFrom”);
    MyMessage.To.Add(new MailAddress(“ToEmail”));
    MyMessage.Subject = “EmailSubject”;
    MyMessage.Body = “EmailBody”;
    Attachment DailyAttachFile = new Attachment(“Full Emage Path”);
    MyMessage.Attachments.Add(DailyAttachFile);
            
    SmtpClient emailClient = new SmtpClient(“SMTPServer”);
    emailClient.Port = int.Parse(“SMTPServerPortNo”);
    emailClient.Send(MyMessage);
    MyMessage.Dispose();
