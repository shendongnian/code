    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
    
    System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment("file path here");
    mail.Attachments.Add(attachment);
    .......[continue with method here]..........
