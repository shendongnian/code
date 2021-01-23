    using(MailMessage m = ...)
    {
        ...
        using (Attachment data = ...)
        { 
            ...
            using (SmtpClient s = ...)
            {
               ...
            }
        }
    }
