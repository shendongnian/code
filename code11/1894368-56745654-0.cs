    int blockSize = 8000000; // 8 MB
    string fileName = "C:\\temp\\6GBTest.odt", uniqueFileName = String.Empty;
    long fileSize;
    Microsoft.SharePoint.Client.File uploadFile = null;
    Guid uploadId = Guid.NewGuid();
     
    using (ClientContext ctx = new ClientContext("siteUrl"))
    {
        ctx.Credentials = new SharePointOnlineCredentials("user@tenant.onmicrosoft.com", GetSecurePassword());
        List docs = ctx.Web.Lists.GetByTitle("Documents");
        ctx.Load(docs.RootFolder, p => p.ServerRelativeUrl);
     
        // Use large file upload approach
        ClientResult<long> bytesUploaded = null;
     
        FileStream fs = null;
        try
        {
            fs = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
     
            fileSize = fs.Length;
            uniqueFileName = System.IO.Path.GetFileName(fs.Name);
     
            using (BinaryReader br = new BinaryReader(fs))
            {
                byte[] buffer = new byte[blockSize];
                byte[] lastBuffer = null;
                long fileoffset = 0;
                long totalBytesRead = 0;
                int bytesRead;
                bool first = true;
                bool last = false;
     
                // Read data from filesystem in blocks
                while ((bytesRead = br.Read(buffer, 0, buffer.Length)) > 0)
                {
                    totalBytesRead = totalBytesRead + bytesRead;
     
                    // We've reached the end of the file
                    if (totalBytesRead <= fileSize)
                    {
                        last = true;
                        // Copy to a new buffer that has the correct size
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
                            uploadFile = docs.RootFolder.Files.Add(fileInfo);
     
                            // Start upload by uploading the first slice.
                            using (MemoryStream s = new MemoryStream(buffer))
                            {
                                // Call the start upload method on the first slice
                                bytesUploaded = uploadFile.StartUpload(uploadId, s);
                                ctx.ExecuteQuery();
                                // fileoffset is the pointer where the next slice will be added
                                fileoffset = bytesUploaded.Value;
                            }
     
                            // we can only start the upload once
                            first = false;
                        }
                    }
                    else
                    {
                        // Get a reference to our file
                        uploadFile = ctx.Web.GetFileByServerRelativeUrl(docs.RootFolder.ServerRelativeUrl + System.IO.Path.AltDirectorySeparatorChar + uniqueFileName);
     
                        if (last)
                        {
                            // Is this the last slice of data?
                            using (MemoryStream s = new MemoryStream(lastBuffer))
                            {
                                // End sliced upload by calling FinishUpload
                                uploadFile = uploadFile.FinishUpload(uploadId, fileoffset, s);
                                ctx.ExecuteQuery();
     
                                // return the file object for the uploaded file
                                return uploadFile;
                            }
                        }
                        else
                        {
                            using (MemoryStream s = new MemoryStream(buffer))
                            {
                                // Continue sliced upload
                                bytesUploaded = uploadFile.ContinueUpload(uploadId, fileoffset, s);
                                ctx.ExecuteQuery();
                                // update fileoffset for the next slice
                                fileoffset = bytesUploaded.Value;
                            }
                        }
                    }
     
                }
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
