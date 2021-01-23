    if (Request.Files.Count > 0)
    {
        HttpFileCollection attachments = Request.Files;
        for (int i = 0; i < attachments.Count; i++)
        {
            HttpPostedFile attachment = attachments[i];
            if (attachment.ContentLength > 0 && !String.IsNullOrEmpty(attachment.FileName))
            {
                //do your file saving or any related tasks here.
            }
        }
    }
