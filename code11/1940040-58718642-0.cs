    LinkedResource inline = new LinkedResource(new MemoryStream(imageData), Image.Jpeg)
    {
        ContentId = contentId,
        TransferEncoding = TransferEncoding.Base64,
        ContentLink = new Uri("cid:" + contentId),
    };
    inline.ContentType.Name = contentId;
    inline.ContentType.MediaType = Image.Jpeg;
