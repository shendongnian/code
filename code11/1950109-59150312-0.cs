    // etc
    List<Task> tasks = new List<Task>();
    foreach( IListBlobItem item in IE )
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
