    //create the mail message
    MailMessage mail = new MailMessage();
    
    //set the addresses
    mail.From = new MailAddress("...");
    mail.To.Add("...");
    
    //set the content
    mail.Subject = "Test mail";
    AlternateView htmlView = AlternateView.CreateAlternateViewFromString("Here is an embedded image." ", null, "text/html");
    
    //create the LinkedResource (embedded image)
    LinkedResource logo = new LinkedResource(GenerateBarcode(Code)));
    logo.ContentId = "logo";
    htmlView.LinkedResources.Add(logo);
    
    mail.AlternateViews.Add(htmlView);
    //send the message
    SmtpClient smtp = new SmtpClient("127.0.0.1"); 
    smtp.Send(mail);
