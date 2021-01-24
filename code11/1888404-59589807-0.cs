           public void PersistPhoto(IFormFile fileToPersist, string saveAsFileName)
           {
                string connectionString= "Azure Storage Connection String";
                string containerName= "Azure Storage Container Name";
                BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
    
                try
                {
                    // Get a reference to a blob
                    BlobClient blob = container.GetBlobClient(saveAsFileName);
    
                    // Open the file and upload its data
                    using (Stream file = fileToPersist.OpenReadStream())
                    {
                        blob.Upload(file);                  
                    }
    
                    uri = blob.Uri.AbsoluteUri;
                }
                catch
                {
                    // log error
                }
            }
