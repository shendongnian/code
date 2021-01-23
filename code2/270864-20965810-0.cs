    if (Request.Files.Count > 0)
    {
        HttpFileCollection Attachments = Request.Files;
        for (int i = 0; i < Attachments.Count; i++)
        {
            HttpPostedFile Attachment = Attachments[i];
            if (Attachment.ContentLength > 0 && !String.IsNullOrEmpty(Attachment.FileName))
            {
                //do your file saving or any related tasks here.
            }
        }
    }
