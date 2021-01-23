    using (var client = new SmtpClient("smtp.foo.com"))
    using (var message = new MailMessage("from@foo.com", "to@bar.com"))
    {
        message.Subject = "test subject";
        message.Body = "test body";
        message.IsBodyHtml = false;
        foreach (var attachment in attachments)
        {
            var attachmentStream = new MemoryStream(attachment);
            // TODO: Choose a better name for your attachments and adapt the MIME type
            var messageAttachment = new Attachment(attachmentStream, Guid.NewGuid().ToString(), "application/octet-stream");
            message.Attachments.Add(messageAttachment);
        }
        client.Send(message);
    }
