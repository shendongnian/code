    static void DownloadBlockListForBlob(Uri blobEndpoint, string accountName, string accountKey)
    {
        //Create service client for credentialed access to the Blob service, using development storage.
        CloudBlobClient blobClient = new CloudBlobClient(blobEndpoint, new StorageCredentialsAccountAndKey(accountName, accountKey)); 
    
        //Get a reference to a block blob.
        CloudBlockBlob blockBlob = blobClient.GetBlockBlobReference("mycontainer/mybinaryblob.mp3");
    
        //Download the committed blocks in the block list.
        foreach (var blockListItem in blockBlob.DownloadBlockList())
        {
            Console.WriteLine("Block ID: " + blockListItem.Name);
            Console.WriteLine("Block size: " + blockListItem.Size);
            Console.WriteLine("Is block committed?: " + blockListItem.Committed);
            Console.WriteLine();
        }
    
        //Download only uncommitted blocks.
        foreach (var blockListItem in blockBlob.DownloadBlockList(BlockListingFilter.Uncommitted))
        {
            Console.WriteLine("Block ID: " + blockListItem.Name);
            Console.WriteLine("Block size: " + blockListItem.Size);
            Console.WriteLine("Is block committed?: " + blockListItem.Committed);
            Console.WriteLine();
        }
    
        //Download all blocks.
        foreach (var blockListItem in blockBlob.DownloadBlockList(BlockListingFilter.All))
        {
            Console.WriteLine("Block ID: " + blockListItem.Name);
            Console.WriteLine("Block size: " + blockListItem.Size);
            Console.WriteLine("Is block committed?: " + blockListItem.Committed);
            Console.WriteLine();
        }
    }
