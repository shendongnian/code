    //  Builds the URI to the blob storage.
    UriBuilder fullUri = new UriBuilder()
    {
        Scheme = "https",
        Host = string.Format("{0}.blob.core.windows.net", <AccountName>),
        Path = string.Format("{0}/{1}", <ContainerName>, <BlobName>),
        Query = sasQueryParameters.ToString()
    };
    
    //  Get an instance of BlobClient using the URI.
    var blobClient = new BlobClient(fullUri.Uri, null);
    
    //  Upload stuff in the blob.
    await blobClient.UploadAsync(stream);
            
