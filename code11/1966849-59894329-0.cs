        using (var memoryStream = postedFile.InputStream as MemoryStream)
        {
            if (memoryStream == null)
                postedFile.InputStream.CopyTo(memoryStream);
            new UploadedFile()
            {
                Name = postedFile.FileName,
                Type = MimeMapping.GetMimeMapping(postedFile.FileName),
                InputBytes = memoryStream?.ToArray()
            };
        }
