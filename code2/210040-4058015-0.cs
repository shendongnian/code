    // Create  the file attachment for this e-mail message.
    			Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
    			// Add time stamp information for the file.
    			ContentDisposition disposition = data.ContentDisposition;
    			disposition.CreationDate = System.IO.File.GetCreationTime(file);
    			disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
    			disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
    			// Add the file attachment to this e-mail message.
    			message.Attachments.Add(data);
