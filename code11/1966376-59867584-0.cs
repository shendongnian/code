    public Microsoft.SharePoint.Client.File UploadFileSlicePerSliceToFolder(ClientContext ctx, string serverRelativeFolderUrl, string fileName, int fileChunkSizeInMB = 3)
    {
      // Each sliced upload requires a unique ID.
      Guid uploadId = Guid.NewGuid();
    
      // Get the name of the file.
      string uniqueFileName = Path.GetFileName(fileName);
    
      // Get the folder to upload into.
      Folder uploadFolder = rootweb.GetFolderByServerRelativeUrl(serverRelativeFolderUrl);
    
      // Get the information about the folder that will hold the file.
      ctx.Load(uploadFolder);
      ctx.ExecuteQuery();
    
      // File object.
      Microsoft.SharePoint.Client.File uploadFile = null;
    
      // Calculate block size in bytes.
      int blockSize = fileChunkSizeInMB * 1024 * 1024;
    
      // Get the information about the folder that will hold the file.
      ctx.Load(uploadFolder, f => f.ServerRelativeUrl);
      ctx.ExecuteQuery();
    
    
      // Get the size of the file.
      long fileSize = new FileInfo(fileName).Length;
    
      if (fileSize <= blockSize)
      {
        // Use regular approach.
        using (FileStream fs = new FileStream(fileName, FileMode.Open))
        {
          FileCreationInformation fileInfo = new FileCreationInformation();
          fileInfo.ContentStream = fs;
          fileInfo.Url = uniqueFileName;
          fileInfo.Overwrite = true;
          uploadFile = uploadFolder.Files.Add(fileInfo);
          ctx.Load(uploadFile);
          ctx.ExecuteQuery();
          // Return the file object for the uploaded file.
          return uploadFile;
        }
      }
      else
      {
        // Use large file upload approach.
        ClientResult<long> bytesUploaded = null;
    
        FileStream fs = null;
        try
        {
          fs = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
          using (BinaryReader br = new BinaryReader(fs))
          {
            byte[] buffer = new byte[blockSize];
            Byte[] lastBuffer = null;
            long fileoffset = 0;
            long totalBytesRead = 0;
            int bytesRead;
            bool first = true;
            bool last = false;
    
            // Read data from file system in blocks.
            while ((bytesRead = br.Read(buffer, 0, buffer.Length)) > 0)
            {
              totalBytesRead = totalBytesRead + bytesRead;
    
              // You've reached the end of the file.
              if (totalBytesRead == fileSize)
              {
                last = true;
                // Copy to a new buffer that has the correct size.
                lastBuffer = new byte[bytesRead];
                Array.Copy(buffer, 0, lastBuffer, 0, bytesRead);
              }
    
              if (first)
              {
                using (MemoryStream contentStream = new MemoryStream())
                {
                  // Add an empty file.
                  FileCreationInformation fileInfo = new FileCreationInformation();
                  fileInfo.ContentStream = contentStream;
                  fileInfo.Url = uniqueFileName;
                  fileInfo.Overwrite = true;
                  uploadFile = uploadFolder.Files.Add(fileInfo);
    
                  // Start upload by uploading the first slice.
                  using (MemoryStream s = new MemoryStream(buffer))
                  {
                    // Call the start upload method on the first slice.
                    bytesUploaded = uploadFile.StartUpload(uploadId, s);
                    ctx.ExecuteQuery();
                    // fileoffset is the pointer where the next slice will be added.
                    fileoffset = bytesUploaded.Value;
                  }
    
                  // You can only start the upload once.
                  first = false;
                }
              }
              else
              {
                if (last)
                {
                  // Is this the last slice of data?
                  using (MemoryStream s = new MemoryStream(lastBuffer))
                  {
                    // End sliced upload by calling FinishUpload.
                    uploadFile = uploadFile.FinishUpload(uploadId, fileoffset, s);
                    ctx.ExecuteQuery();
    
                    // Return the file object for the uploaded file.
                    return uploadFile;
                  }
                }
                else
                {
                  using (MemoryStream s = new MemoryStream(buffer))
                  {
                    // Continue sliced upload.
                    bytesUploaded = uploadFile.ContinueUpload(uploadId, fileoffset, s);
                    ctx.ExecuteQuery();
                    // Update fileoffset for the next slice.
                    fileoffset = bytesUploaded.Value;
                  }
                }
              }
            } // while ((bytesRead = br.Read(buffer, 0, buffer.Length)) > 0)
          }
        }
        finally
        {
          if (fs != null)
          {
            fs.Dispose();
          }
        }
      }
    
      return null;
    }
