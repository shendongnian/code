    MailMessage mailMsg = new MailMessage();
    SmtpClient client = new SmtpClient();
    
    client.Port = 587;
    client.Host = "mail.youdomain.com"; //////EDITED
    client.EnableSsl = false; //////EDITED
    client.Credentials = new System.Net.NetworkCredential(username, password);
    MailAddress mailAdd = new MailAddress("jack2@gmail.com");
    
    mailMsg.Sender = new MailAddress(username);
    mailMsg.From = mailAdd;
    //mailMsg.Headers.Add("Sender",username);
    mailMsg.Bcc.Add(builder.ToString());
    
    mailMsg.Subject = txtSubject.Text;
    mailMsg.Body = txtBody.Text;
    mailMsg.IsBodyHtml = chkHtmlBody.Checked;
    if (System.IO.File.Exists(txtAttechments.Text))
    {
    System.Net.Mail.Attachment attechment = new Attachment(txtAttechments.Text);
    mailMsg.Attachments.Add(attechment);
    }
    
    client.Send(mailMsg);
