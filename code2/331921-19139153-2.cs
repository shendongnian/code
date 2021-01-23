    var contentID = "Image";
    var inlineLogo = new Attachment(@"C:\Desktop\Image.jpg");
    inlineLogo.ContentId = contentID;
    inlineLogo.ContentDisposition.Inline = true;
    inlineLogo.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
    msg.IsBodyHtml = true;
    msg.Attachments.Add(inlineLogo);
    msg.Body = "<htm><body> <img src=\"cid:" + contentID + "\"> </body></html>";
