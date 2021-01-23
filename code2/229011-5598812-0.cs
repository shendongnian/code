        // get the info for every blob in the container
        var blobInfos = cloudBlobContainer.ListBlobs(
            new BlobRequestOptions() { UseFlatBlobListing = true });
        Parallel.ForEach(blobInfos, (blobInfo) =>
        {
            // get the blob properties
            CloudBlob blob = container.GetBlobReference(blobInfo.Uri.ToString());
            blob.FetchAttributes();
    
            // set cache-control header if necessary
            if (blob.Properties.CacheControl != YOUR_CACHE_CONTROL_HEADER)
            {
                blob.Properties.CacheControl = YOUR_CACHE_CONTROL_HEADER;
                blob.SetProperties();
            }
        });
    
