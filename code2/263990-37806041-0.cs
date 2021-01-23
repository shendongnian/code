    MailMessage mailMessage = new MailMessage();
    Attachment attachment = new Attachment(myMemorySteam, new ContentType(MediaTypeNames.Application.Octet));
    attachment.ContentDisposition.FileName = "myFile.xlsx";
    attachment.ContentDisposition.Size = attachment.Length;
    mailMessage.Attachments.Add(attachment);
