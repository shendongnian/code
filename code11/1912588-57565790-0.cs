      CloudBlobContainer blobContainer = blobClient.GetContainerReference("xxx");
      CloudBlockBlob myblob = blobContainer.GetBlockBlobReference("xxx");
    
      myblob.Properties.ContentEncoding = "SJIS";
      myblob.SetProperties();
