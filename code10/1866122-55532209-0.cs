    var mimeMessage = MimeMessage.Load(@"test.eml");
    var attachments = mimeMessage.Attachments.ToList();
    
    foreach (var attachment in attachments)
    {
        using (var memory = new MemoryStream())
        {
            if (attachment is MimePart)
                ((MimePart)attachment).Content.DecodeTo(memory);
            else
                ((MessagePart)attachment).Message.WriteTo(memory);
    
            var bytes = memory.ToArray();
        }
    }
