async Task CopyBlobsAsync()
{
    const String ContainerName    = "old-container-name";
    const String NewContainerName = "new-container-name";
    
    CloudStorageAccount storageAccount = CloudStorageAccount.Parse( CloudConfigurationManager.GetSetting("StorageConnectionString") );
    CloudBlobClient     blobClient     = storageAccount.CreateCloudBlobClient();
    CloudBlobContainer  container      = blobClient.GetContainerReference( ContainerName );
    CloudBlobContainer  destcontainer  = blobClient.GetContainerReference( NewContainerName );
    
    await destcontainer.CreateIfNotExistsAsync( BlobContainerPublicAccessType.Blob );
    
    List<IListBlobItem> blobs = await ListBlobsAsync( container ).ConfigureAwait(false);
    List<Task>          tasks = new List<Task>();
    foreach( IListBlobItem item in blobs )
    {
        if( item is CloudBlockBlob blob )
        {
            CloudBlockBlob destBlob = destcontainer.GetBlockBlobReference( blob.Name );
            Uri destUri = new Uri( GetSharedAccessUri( blob.Name, container ) );
            Task task = destBlob.StartCopyAsync( destUri  );
            tasks.Add( task );
        }
    }
    await Task.WhenAll( tasks ).ConfigureAwait(false);
}
// From https://ahmet.im/blog/azure-listblobssegmentedasync-listcontainerssegmentedasync-how-to/
async Task<List<IListBlobItem> ListBlobsAsync( CloudBlobContainer container )
{
	BlobContinuationToken continuationToken = null;
	List<IListBlobItem> results = new List<IListBlobItem>();
    do
    {
        var response = await ListBlobsSegmentedAsync( continuationToken );
        continuationToken = response.ContinuationToken;
        results.AddRange( response.Results );
    }
    while( continuationToken != null );
    return results;
}
