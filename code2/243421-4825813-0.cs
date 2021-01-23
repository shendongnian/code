     public static void SendMail(string email, string message)
            {
                // Algorithm :: A MailMessage object is created and the details such as FromAddress, ToAddress, Subject, Body are included and the mail is sent.
                MailMessage newmessage = new MailMessage();
                try
                {
                    newmessage.From = new MailAddress("email", "subject");
                    newmessage.To.Add(new MailAddress(email));
                    newmessage.Subject = "Hii Friends..";
                    newmessage.Body += message;
                    newmessage.IsBodyHtml = true;
    
                    SmtpClient client = new SmtpClient("smtp.gmail.com");
                    //SmtpClient client = new SmtpClient("smtp.mail.yahoo.com");
                    //client.Port = 587; yahoo port number
    
                    client.EnableSsl = true;
                    string path = System.Web.HttpContext.Current.Server.MapPath(@"logo.png");
                    AlternateView plainView = AlternateView.CreateAlternateViewFromString("This is my text , viewable by those clients that don't support html", null, "text/plain");
    
                    LinkedResource logo = new LinkedResource(path);
                    logo.ContentId = "companylogo";
                    AlternateView av1 = AlternateView.CreateAlternateViewFromString("<html><body><img src=cid:companylogo/><br></body></html>" + message, null, MediaTypeNames.Text.Html);
                    av1.LinkedResources.Add(logo);
    
                    newmessage.AlternateViews.Add(plainView);
                    newmessage.AlternateViews.Add(av1);
    
                    if (!string.IsNullOrEmpty("mail"))
                    {
                        client.Credentials = new NetworkCredential("mail", "password");
                    }
                    client.Send(newmessage);
                }
                catch
                {
                }
                return;
            }
