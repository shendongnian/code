                string rootpath = null;
    
                rootpath = Environment.GetEnvironmentVariable("HOME") + @"\site\wwwroot" + @"\test.jpg";
                
                MailMessage mailMessage = new MailMessage();
    
                mailMessage.From = new MailAddress("xxxxxxxxxx");
    
                mailMessage.To.Add(new MailAddress("xxxxxxxxxxxx"));
    
                mailMessage.Subject = "message image test";
    
                mailMessage.IsBodyHtml = true;
                string content = "If your mail client does not support HTML format, please switch to the 'Normal Text' view and you will see this content.";
                mailMessage.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(content, null, "text/plain"));
                mailMessage.Body += "<br /><img src=\"cid:weblogo\">"; 
 
                AlternateView htmlBody = AlternateView.CreateAlternateViewFromString(mailMessage.Body, null, "text/html");
                LinkedResource lrImage = new LinkedResource(rootpath, "image/jpg");
                lrImage.ContentId = "weblogo"; 
                htmlBody.LinkedResources.Add(lrImage);
                mailMessage.AlternateViews.Add(htmlBody);
               
                SmtpClient client = new SmtpClient();
    
                client.Host = "smtp.qq.com";
    
                client.EnableSsl = true;
    
                client.UseDefaultCredentials = false;
    
                client.Credentials = new NetworkCredential("xxxxxxxxxx", "xxxxxxxxxx");
    
                client.Send(mailMessage);
