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
