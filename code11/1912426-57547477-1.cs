        public static string UploadFile()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("{Connection String}");
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("toosee");
            CloudBlockBlob blockBlob = container.GetBlockBlobReference("customer_address.png");
            blockBlob.Properties.ContentType = "image/png";
            blockBlob.UploadFromFile(@"C:\\Temp\\customer_address.PNG");
            return blockBlob.Uri.ToString();
        }
