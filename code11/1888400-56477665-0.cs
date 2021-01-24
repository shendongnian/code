    string storageConnectionString = "<connection_string>";
    CloudStorageAccount storageacc = CloudStorageAccount.Parse(storageConnectionString);
    
    CloudBlobClient blobClient = storageacc.CreateCloudBlobClient();
    CloudBlobContainer container = blobClient.GetContainerReference("images");
    container.CreateIfNotExists();
    
    CloudBlockBlob blockBlob = container.GetBlockBlobReference("11173.jpg");
    
    using (var filestream = System.IO.File.OpenRead(@"C:\\Users\\John\\Desktop\\11173.jpg"))
    {
        blockBlob.UploadFromStream(filestream);
    }
