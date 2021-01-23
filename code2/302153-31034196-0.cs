      if (model.Attachment != null && model.Attachment.ContentLength > 0)
        {
        foreach (HttpPostedFileBase item in fileUploader)
          {
    
            var attachment = new Attachment(model.Attachment.InputStream,   model.Attachment.FileName);
            mail.Attachments.Add(attachment);
          }
        }
