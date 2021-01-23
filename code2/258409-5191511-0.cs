    using (Attachment data = new Attachment(filePath, MediaTypeNames.Application.Octet))
    {
        // Add time stamp information for the file.             
        ContentDisposition disposition = data.ContentDisposition;   
        disposition.CreationDate = System.IO.File.GetCreationTime(filePath);
        disposition.ModificationDate = System.IO.File.GetLastWriteTime(filePath);
        disposition.ReadDate = System.IO.File.GetLastAccessTime(filePath);
        // Add the file attachment to this e-mail message.
        message.Attachments.Add(data); 
        // Add your send code in here too
    }
