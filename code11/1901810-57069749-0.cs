    CloudBlobContainer rootContainer = blobClient.GetContainerReference("sample");
    CloudBlobDirectory dir1;
    var items = rootContainer.ListBlobs(id + "/someData/" + somedataid.ToString() + "/", false);
    
    foreach (var blob in items.OfType<CloudBlob>()
        .OrderByDescending(b => b.Properties.LastModified).Skip(1000).Take(500))
   
     {
    
    }
