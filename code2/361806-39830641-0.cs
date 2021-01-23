    System.Net.Mail
============
    string senderID = "myemailID@mydomain.com";
    string senderPassword = "123456";
    string body = " Test email ";
    
    MailMessage mail = new MailMessage();
    mail.To.Add(username);
    //mail.CC.Add(_cc);
    mail.From = new MailAddress(senderID);
    mail.Priority = MailPriority.High;
    mail.Subject = "Test Email";
    mail.Body = body;
    mail.IsBodyHtml = true;
    SmtpClient smtp = new SmtpClient();
    smtp.Host = "relay-hosting.secureserver.net"; //Or Your SMTP Server Address
    smtp.Credentials = new System.Net.NetworkCredential
         (senderID, senderPassword); // ***use valid credentials***
    smtp.Port = 25;
    smtp.EnableSsl = false;
    smtp.Send(mail);
