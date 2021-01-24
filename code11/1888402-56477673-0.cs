    string storageConnectionString = "<connection_string>";
    CloudStorageAccount storageacc = CloudStorageAccount.Parse(storageConnectionString);
    
    CloudBlobClient blobClient = storageacc.CreateCloudBlobClient();
    CloudBlobContainer container = blobClient.GetContainerReference("myblob");
    container.CreateIfNotExists();
    
    CloudBlockBlob blockBlob = container.GetBlockBlobReference("images/11173.jpg");
    blockBlob.Properties.ContentType = "image/jpg";
    using (var filestream = System.IO.File.OpenRead(@"C:\\Users\\John\\Desktop\\11173.jpg"))
    {
        blockBlob.UploadFromStream(filestream);
    }
