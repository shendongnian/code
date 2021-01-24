     static void Main(string[] args)
        {
            string storageConnectionString = "connectin string";
            // Check whether the connection string can be parsed.
            CloudStorageAccount storageAccount;
            CloudStorageAccount.TryParse(storageConnectionString, out storageAccount);
            var containerName = "test";
            var blobName = "testfile.zip";
            string saveFileName = @"E:\testfilefolder\myfile1.zip";
            var blobContainer = storageAccount.CreateCloudBlobClient().GetContainerReference(containerName);
            var blob = blobContainer.GetBlockBlobReference(blobName);
            var sas =blob.GetSharedAccessSignature(new SharedAccessBlobPolicy()
            {
                SharedAccessStartTime = DateTime.UtcNow.AddHours(-5),
                SharedAccessExpiryTime = DateTime.UtcNow.AddHours(5),
                Permissions = SharedAccessBlobPermissions.Read
            });
            string blobSasUri = (string.Format(CultureInfo.InvariantCulture, "{0}{1}", blob.Uri, sas));
            //Download Blob through SAS url
            CloudBlockBlob blobSas = new CloudBlockBlob(new Uri(blobSasUri));
            long startPosition = 0;
            using (MemoryStream ms = new MemoryStream())
            {
                blobSas.DownloadToStream(ms);
                byte[] data = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(data, 0, data.Length);
                using (FileStream fs = new FileStream(saveFileName, FileMode.OpenOrCreate))
                {
                    fs.Position = startPosition;
                    fs.Write(data, 0, data.Length);
                }
            }
        }
