    IEnumerable<string> attachments = null;
    using (var message = new MailMessage())
    {
        ...
        attachments = message.Attachments
            .Select(a => a.ContentStream)
            .OfType<FileStream>()
            .Select(fs => fs.Name);
    }
    
    foreach (var attachment in attachments )
    {
        File.Delete(attachment);
    }
