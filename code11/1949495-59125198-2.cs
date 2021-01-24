    //  Creates a client to the BlobService using the connection string.
    var blobServiceClient = new BlobServiceClient(storageConnectionString);
    
    //  Gets a reference to the container.
    var blobContainerClient = blobServiceClient.GetBlobContainerClient(<ContainerName>);
    
    //  Gets a reference to the blob in the container
    BlobClient blobClient = containerClient.GetBlobClient(<BlobName>);
    
    //  Defines the resource being accessed and for how long the access is allowed.
    var blobSasBuilder = new BlobSasBuilder
    {
        StartsOn = DateTime.UtcNow.Subtract(clockSkew), 
        ExpiresOn = DateTime.UtcNow.Add(accessDuration) + clockSkew,
        BlobContainerName = <ContainerName>,
        BlobName = <BlobName>,
    };
        
    //  Defines the type of permission.
    blobSasBuilder.SetPermissions(BlobSasPermissions.Write);
           
    //  Builds an instance of StorageSharedKeyCredential      
    var storageSharedKeyCredential = new StorageSharedKeyCredential(<AccountName>, <AccountKey>);
    
    //  Builds the Sas URI.
    BlobSasQueryParameters sasQueryParameters = blobSasBuilder.ToSasQueryParameters(storageSharedKeyCredential);
