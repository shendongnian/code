    public static async Task test()
    {
        StorageCredentials storageCredentials = new StorageCredentials("xxx", "xxxxx");
        CloudStorageAccount storageAccount = new CloudStorageAccount(storageCredentials, true);
        CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
        CloudBlobContainer container = blobClient.GetContainerReference("container");
        BlobContinuationToken blobContinuationToken = null;
        var resultSegment = await container.ListBlobsSegmentedAsync(
             prefix: null,
             useFlatBlobListing: true,
             blobListingDetails: BlobListingDetails.None,
             maxResults: null,
             currentToken: blobContinuationToken,
             options: null,
             operationContext: null
         );
    
         // Get the value of the continuation token returned by the listing call.
         blobContinuationToken = resultSegment.ContinuationToken;
         foreach (IListBlobItem item in resultSegment.Results)
         {
              Console.WriteLine(item.Uri);
         }
    }
