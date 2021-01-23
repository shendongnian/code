        public async Task BackfillCacheControlAsync()
        {
            var container = await GetCloudBlobContainerAsync();
            BlobContinuationToken continuationToken = null;
            do
            {
                var blobInfos = await container.ListBlobsSegmentedAsync(string.Empty, true, BlobListingDetails.None, null, continuationToken, null, null);
                continuationToken = blobInfos.ContinuationToken;
                foreach (var blobInfo in blobInfos.Results)
                {
                    var blockBlob = (CloudBlockBlob)blobInfo;
                    var blob = await container.GetBlobReferenceFromServerAsync(blockBlob.Name);
                    if (blob.Properties.CacheControl != "public, max-age=31536000")
                    {
                        blob.Properties.CacheControl = "public, max-age=31536000";
                        await blob.SetPropertiesAsync();
                    }
                }               
            }
            while (continuationToken != null);
        }
        private async Task<CloudBlobContainer> GetCloudBlobContainerAsync()
        {
            var storageAccount = CloudStorageAccount.Parse(_appSettings.AzureStorageConnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("uploads");
            return container;
        }
