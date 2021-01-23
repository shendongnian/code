    string htmlBody = "<html><body><h1>Picture</h1><br><img src=\"cid:Pic1\"></body></html>";
    AlternateView avHtml = AlternateView.CreateAlternateViewFromString
        (htmlBody, null, MediaTypeNames.Text.Html);
    
    // Create a LinkedResource object for each embedded image
    LinkedResource pic1 = new LinkedResource("pic.jpg", MediaTypeNames.Image.Jpeg);
    pic1.ContentId = "Pic1";
    avHtml.LinkedResources.Add(pic1);
    
    
    // Add the alternate views instead of using MailMessage.Body
    MailMessage m = new MailMessage();
    m.AlternateViews.Add(avHtml);
    
    // Address and send the message
    m.From = new MailAddress("email1@host.com", "From guy");
    m.To.Add(new MailAddress("email2@host.com", "To guy"));
    m.Subject = "A picture using alternate views";
    SmtpClient client = new SmtpClient("mysmtphost.com");
    client.Send(m);
