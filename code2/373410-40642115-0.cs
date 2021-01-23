                    myMessage.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(HtmlMessage, new System.Net.Mime.ContentType("text/html")));
            myMessage.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(TextMessage, new System.Net.Mime.ContentType("text/plain")));
        //    myMessage.Body = HtmlMessage;
        //    myMessage.IsBodyHtml = true;
            myClient.UseDefaultCredentials = false;
            NetworkCredential credentials = new NetworkCredential("xxxx","xxxxx");
            myClient.Credentials = credentials;
            myClient.DeliveryMethod = SmtpDeliveryMethod.Network;
    
