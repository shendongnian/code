    // Tuple contains displayName and byte[] content for attachment in this case
    List<Tuple<string,byte[]>> attachmentContent;
    MailMessage email = BuildNativeEmail(requestObject, out attachmentContent);
    List<MemoryStream> streams = new List<MemoryStream>();
    foreach(Tuple<string,byte[]> attachment in attachmentContent)
    {
        MemoryStream m = new MemoryStream(attachment.Item2);
        email.Attachments.Add(new System.Net.Mail.Attachment(m, attachment.Item1));
        streams.add(m);
    }
    
    // client represents a System.Net.Mail.SmtpClient object
    client.Send(email);
    
    foreach(MemoryStream stream in streams)
    {
        stream.Dispose();
    }
