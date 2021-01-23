            AlternateView avHtml = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);
            LinkedResource inline = new LinkedResource(System.Web.HttpContext.Current.Server.MapPath("~/Images/e1.jpg"), MediaTypeNames.Image.Jpeg);
            inline.ContentId = "1";
            inline.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
            avHtml.LinkedResources.Add(inline);
            LinkedResource inline1 = new LinkedResource(System.Web.HttpContext.Current.Server.MapPath("~/CImages/2.jpg"), MediaTypeNames.Image.Jpeg);
            inline1.ContentId = "2";
            inline1.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
            avHtml.LinkedResources.Add(inline1);
            LinkedResource inline2 = new LinkedResource(System.Web.HttpContext.Current.Server.MapPath("~/Images/3.jpg"), MediaTypeNames.Image.Jpeg);
            inline2.ContentId = "3";
            inline2.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
            avHtml.LinkedResources.Add(inline2);
            LinkedResource inline3 = new LinkedResource(System.Web.HttpContext.Current.Server.MapPath("~/Content/Images/4.jpg"), MediaTypeNames.Image.Jpeg);
            inline3.ContentId = "4";
            inline3.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
            avHtml.LinkedResources.Add(inline3);
            MailMessage mail = new MailMessage();
            mail.AlternateViews.Add(avHtml);
    
            HTML:
           <img src="cid:1" alt="" />
           <img src="cid:2" alt="" />
           <img src="cid:3" alt="" /`
           <img src="cid:4" alt="" />
