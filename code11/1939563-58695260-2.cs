        /// <summary>
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileName"></param>
        /// <param name="connectionString"></param>
        /// <param name="containerName"></param>
        /// <param name="blobContentType"></param>
        /// <returns></returns>
        public static async Task<string> AzureUpload(this Stream file, string fileName, string connectionString, string containerName, string blobContentType = null)
        {
            CloudBlobClient blobClient = CloudStorageAccount.Parse(connectionString).CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            if (await container.CreateIfNotExistsAsync())
            {
               // Comment this code below if you don't want your files
               // to be publicly available. By default, a container is private.
               // You can see more on how
               // to set different container permissions at: 
               // https://docs.microsoft.com/en-us/azure/storage/blobs/storage-manage-access-to-resources
                await container.SetPermissionsAsync(new BlobContainerPermissions() { PublicAccess = BlobContainerPublicAccessType.Blob });
            }
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
            await blockBlob.UploadFromStreamAsync(file);
            blobContentType = blobContentType.HasValue() ? blobContentType : getBlobContentType(fileName);
            if (blobContentType.HasValue())
            {
                blockBlob.Properties.ContentType = blobContentType;
                await blockBlob.SetPropertiesAsync();
            }
            return blockBlob.Uri.AbsoluteUri;
        }
