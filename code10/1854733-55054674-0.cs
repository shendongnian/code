    var attachment = new MimePart("application", "octet-stream")
    {
        Content = new MimeContent(File.OpenRead(file), ContentEncoding.Default),
        ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
        ContentTransferEncoding = ContentEncoding.Base64,
        FileName = Path.GetFileName(file),
    };
    attachment.Headers.Replace("Content-Transfer-Encoding", "******");
