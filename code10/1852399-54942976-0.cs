    public string UploadFile(string sourceFilePath)
    {
        try
        {
            string storageAccountConnectionString = "AZURE_CONNECTION_STRING";
            CloudStorageAccount StorageAccount = CloudStorageAccount.Parse(storageAccountConnectionString);
            CloudBlobClient BlobClient = StorageAccount.CreateCloudBlobClient();
            CloudBlobContainer Container = BlobClient.GetContainerReference("container-name");
            Container.CreateIfNotExists();
            CloudBlockBlob blob = Container.GetBlockBlobReference( Path.GetFileName(sourceFilePath) );
            HashSet<string> blocklist = new HashSet<string>();
            byte[] fileContent = File.ReadAllBytes(sourceFilePath);
            const int pageSizeInBytes = 10485760;
            long prevLastByte = 0;
            long bytesRemain = fileContent.Length;
            do
            {
                long bytesToCopy = Math.Min(bytesRemain, pageSizeInBytes);
                byte[] bytesToSend = new byte[bytesToCopy];
                Array.Copy(fileContent, prevLastByte, bytesToSend, 0, bytesToCopy);
                prevLastByte += bytesToCopy;
                bytesRemain -= bytesToCopy;
                //create blockId
                string blockId = Guid.NewGuid().ToString();
                string base64BlockId = Convert.ToBase64String(Encoding.UTF8.GetBytes(blockId));
                blob.PutBlock(
                    base64BlockId,
                    new MemoryStream(bytesToSend, true),
                    null
                    );
                blocklist.Add(base64BlockId);
            } while (bytesRemain > 0);
            //post blocklist
            blob.PutBlockList(blocklist);
            return "Success";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
