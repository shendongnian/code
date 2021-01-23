            string html = "<html><img src='cid:Image01'></html>";
            byte[] imageBytes = { /* Image Bytes here */ };
            MailMessage m = new MailMessage();
            AlternateView av = AlternateView.CreateAlternateViewFromString(html);
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                LinkedResource res = new LinkedResource(ms);
                res.ContentId = "Image01";
                av.LinkedResources.Add(res);
            }
            m.AlternateViews.Add(av);
