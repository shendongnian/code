        if (myFiles != null)
        {
            foreach (var file in myFiles)
            {
                if (file != null && file.ContentLength > 0)
                {
                    //MemoryStream stream = new MemoryStream(file.ContentLength);
                    //stream.Position = 0;
                    attachements.Add(new EmailAttachments
                    {
                        FileName = file.FileName,
                        ContentType = file.ContentType,
                        Stream = file.InputStream
                    });
                }
            }
        }
