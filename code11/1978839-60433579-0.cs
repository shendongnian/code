    string connectionString = "storage connection string";
    
                // Create a BlobServiceClient object which will be used to create a container client
                BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
    
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("container1");
    
                Pageable<BlobItem> blobs = containerClient.GetBlobs(prefix: "images");
    
                foreach (var blob in blobs)
                {
                    Console.WriteLine(blob.Name);
                }
