    BlobServiceClient blobServiceClient = new BlobServiceClient(azureStorageAccountConnectionString);
    BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(azureStorageAccountContainerName);
    containerClient.CreateIfNotExists();
    if (appendData)
    {
    	var appendBlobClient = containerClient.GetAppendBlobClient(string.Format("{0}/{1}", tenantName, Path.GetFileName(filePath)));
    	appendBlobClient.CreateIfNotExists();
    	var appendBlobMaxAppendBlockBytes = appendBlobClient.AppendBlobMaxAppendBlockBytes;
    	using (var file = File.OpenRead(filePath))
    	{
    		int bytesRead;
    		var buffer = new byte[appendBlobMaxAppendBlockBytes];
    		while ((bytesRead = file.Read(buffer, 0, buffer.Length)) > 0)
    		{
    			Stream stream = new MemoryStream(buffer);
    			appendBlobClient.AppendBlock(stream);
    		}
    	}
    }
    else
    {
    	var blockBlobClient = containerClient.GetBlockBlobClient(string.Format("{0}/{1}", tenantName, Path.GetFileName(filePath)));
    	using FileStream uploadFileStream = File.OpenRead(filePath);
    	blockBlobClient.DeleteIfExists();
    	blockBlobClient.Upload(uploadFileStream);
    	uploadFileStream.Close();
    }
