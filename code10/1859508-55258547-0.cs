          // Storage credentials
            StorageCredentials credentials = new StorageCredentials("accName", "keyValue");
            CloudStorageAccount storageAccount = new CloudStorageAccount(credentials, true);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("theContainer");
            // Continuation Token
            BlobContinuationToken token = null;
            do
            {
      
                var results = await container.ListBlobsSegmentedAsync(null, true, BlobListingDetails.All,
                    null, token, null, null);
                // Cast blobs to type CloudBlockBlob
                var blobs = results.Results.Cast<CloudBlockBlob>().ToList();
                foreach (var blob in blobs)
                {
                    if (Path.GetExtension(blob.Uri.AbsoluteUri) == ".pdf")
                    {
                        blob.Properties.ContentType = "application/pdf";
                    }
                    await blob.SetPropertiesAsync();
                }
            } while (token != null);
