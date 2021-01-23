        message.IsBodyHtml = true;
        string html = RegisterMessageBodyHtml(recvrName, verCode,NewUserID);
        string plain = RegisterMessageBodyPlaintext(recvrName, verCode, NewUserID);
        message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, new ContentType("text/html"));
        message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(plain, new ContentType("text/plain"));
