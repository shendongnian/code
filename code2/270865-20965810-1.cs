    if (Request.Files.Count > 0)
    {
        HttpFileCollection Attachments = Request.Files;
        for (int i = 0; i < Attachments.Count; i++)
        {
            HttpPostedFile attachment = Attachments[i];
            if (attachment.ContentLength > 0 && !String.IsNullOrEmpty(attachment.FileName))
            {
                //do your file saving or any related tasks here.
            }
        }
    }
