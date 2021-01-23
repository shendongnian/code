    using (var client = new SmtpClient())
    {
        var mail = new MailMessage();
        mail.To.Add("toaddress@gmail.com");
        mail.Subject = "Test mail";
        mail.Body = model.Question;
        if (model.Attachment != null && model.Attachment.ContentLength > 0)
        {
            var attachment = new Attachment(model.Attachment.InputStream, model.Attachment.FileName);
            mail.Attachments.Add(attachment);
        }
        client.Send(mail);
    }
