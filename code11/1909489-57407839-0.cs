        public IActionResult Contact()
        {
            string account_name = "xx";
            string account_key = "xx";
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(account_name, account_key), true);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference("test1");
            CloudBlockBlob blob = blobContainer.GetBlockBlobReference("df1.JPG");
            if (!blob.Exists())
            {
                blob.Undelete();
            }
            
            MemoryStream memoryStream = new MemoryStream();
            blob.DownloadToStream(memoryStream);
            memoryStream.Position = 0;
            string contentType = blob.Properties.ContentType;
           blob.DeleteIfExists();
            return new FileStreamResult(memoryStream, contentType)
            {
                FileDownloadName = blob.Name
            };
           
        }
