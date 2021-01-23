    MailAddress sendFrom = new MailAddress(txtFrom.Text);
    MailAddress sendTo = new MailAddress(txtTo.Text);
    
    MailMessage myMessage = new MailMessage(sendFrom, sendTo);
    
    MyMessage.Subject = txtSubject.Text;
    MyMessage.Body = txtBody.Text;
    
    Attachment attachFile = new Attachment(txtAttachmentPath.Text);
    MyMessage.Attachments.Add(attachFile);
    
    SmtpClient emailClient = new SmtpClient(txtSMTPServer.Text);
    emailClient.Send(myMessage);
