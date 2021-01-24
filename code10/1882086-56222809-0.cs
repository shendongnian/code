        static void SaveTextAsBlob()
        {
            var storageAccount = CloudStorageAccount.Parse("storage-account-connection-string");
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("container-name");
            var blob = container.GetBlockBlobReference("blob-name.csv");
            blob.Properties.ContentType = "text/csv";
            string blobContents = GetCsvTextSomehow();
            blob.UploadText(blobContents);
        }
