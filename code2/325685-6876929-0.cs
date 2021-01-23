    MailMessage message = new MailMessage("recipient@example.com", "", ""			    
                          "subject",
                          "mail body");
    Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
    ContentDisposition disposition = data.ContentDisposition;
    disposition.FileName = "thefilenameyouwanttouseintheemail.ext";
    message.Attachments.Add(data);
