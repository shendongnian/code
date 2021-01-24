    try
        {
            bool flag = false;
    if(!flag)
    {        
            SmtpClient client = new SmtpClient("sg2nlvphout-v01.shr.prod.sin2.secureserver.net", 25);
            client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("email@domain.com", "password");
            MailMessage msgobj = new MailMessage();
            msgobj.To.Add(email);
            msgobj.From = new MailAddress("email@domain.com");
            msgobj.Subject = "Subject";
            msgobj.Body = body;
            AlternateView altView = AlternateView.CreateAlternateViewFromString(msgobj.Body, null, MediaTypeNames.Text.Html);
    
            msgobj.AlternateViews.Add(altView);
    
            client.Send(msgobj);
            flag = true;
    }
        }
        catch (Exception ex)
        {
    
        }
