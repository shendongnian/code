    using (MemoryStream ms = new MemoryStream(results, 0 , results.Length, false, true))
    {
        MailMessage msg = new MailMessage(...);
        ContentType ct = new ContentType()
        {
            MediaType = MediaTypeNames.Application.Octet,
            Name = "DetailedQuote.pdf"
        };
        Attachment att = new Attachment(ms, ct);
        msg.Attachments.Add(att);
    }
