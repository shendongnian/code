csharp
for (int x = 0; x < Request.Files.Count; x++)
        {
            HttpPostedFile PostedFile = Request.Files[x];
            if (PostedFile != null && PostedFile.ContentLength > 0)
            {
                try
                {
                    message.Attachments.Add(new Attachment(PostedFile.InputStream,  PostedFile.FileName));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
