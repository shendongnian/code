    System.Net.Mime.ContentType ct 
                = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Text.Html);
    HtmlAttachments.Select( str => new Attachment(str.ToStream(), ct))
                   .ToList()
                   .ForEach( html => mailMessage.Attachments.Add(html));
    
    ... {Usual loading of to/from etc }
    
    client.Send(mailMessage);
