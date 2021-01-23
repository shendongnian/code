    try
    
            {
    
                MailMessage mail = new MailMessage();
    
                mail.To.Add("to@gmail.com");
    
                mail.From = new MailAddress("from@gmail.com");
    
                mail.Subject = "Test with Image";
    
                string Body = "<b>Welcome</b><br><BR>Online resource for .net articles.<BR><img alt=\"\" hspace=0 src=\"cid:imageId\" align=baseline border=0 >";
    
     
    
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(Body, null, "text/html");
    
                LinkedResource imagelink = new LinkedResource(Server.MapPath(".") + @"\codedigest.png", "image/png");
    
                imagelink.ContentId = "imageId";
    
                imagelink.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
    
                htmlView.LinkedResources.Add(imagelink);
    
                mail.AlternateViews.Add(htmlView);
    
                SmtpClient smtp = new SmtpClient();
    
                smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
    
                smtp.Send(mail);
    
            }
    
            catch (Exception ex)
    
            {
    
                Response.Write(ex.Message);
    
            }
