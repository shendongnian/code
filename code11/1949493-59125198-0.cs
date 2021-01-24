    //  Defines the resource being accessed and for how long the access is allowed.
    var blobSasBuilder = new BlobSasBuilder
    {
        StartsOn = DateTime.UtcNow.Subtract(clockSkew), 
        ExpiresOn = DateTime.UtcNow.Subtract(clockSkew),
        BlobContainerName = <the container name>
        BlobName = <the blob name>,
    };
    
    //  Defines the type of permission.
    blobSasBuilder.SetPermissions(BlobSasPermissions.Write);
            
