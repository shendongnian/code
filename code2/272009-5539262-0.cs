    MailMessage nMail = new MailMessage();
    nMail.To.Add("new.address@test.com");
    nMail.From = new MailAddress("me@me.com");
    Mail.Subject = (" ");
    nMail.Body = ("Line<br/>New line"); 
    nMail.IsBodyHtml = true;                                                  
    SmtpClient sc = new SmtpClient("our server");
    sc.Credentials = new System.Net.NetworkCredential("login", "pwd");
    sc.Send(nMail);
