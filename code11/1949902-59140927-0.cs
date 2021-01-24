        static void RenameContainer()
        {
            var connectionString = "DefaultEndpointsProtocol=https;AccountName=account-name;AccountKey=account-key";
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var client = storageAccount.CreateCloudBlobClient();
            var sourceContainer = client.GetContainerReference("source-container");
            var targetContainer = client.GetContainerReference("target-container");
            targetContainer.CreateIfNotExists();//Create target container
            BlobContinuationToken continuationToken = null;
            do
            {
                Console.WriteLine("Listing blobs. Please wait...");
                var blobsResult = sourceContainer.ListBlobsSegmented(prefix: "", useFlatBlobListing: true, blobListingDetails: BlobListingDetails.All, maxResults: 1000, currentToken: continuationToken, options: new BlobRequestOptions(), operationContext: new OperationContext());
                continuationToken = blobsResult.ContinuationToken;
                var items = blobsResult.Results;
                foreach (var item in items)
                {
                    var blob = (CloudBlob)item;
                    var targetBlob = targetContainer.GetBlobReference(blob.Name);
                    Console.WriteLine(string.Format("Copying \"{0}\" from \"{1}\" blob container to \"{2}\" blob container.", blob.Name, sourceContainer.Name, targetContainer.Name));
                    targetBlob.StartCopy(blob.Uri);
                }
            } while (continuationToken != null);
            Console.WriteLine("Deleting source blob container. Please wait.");
            //sourceContainer.DeleteIfExists();
            Console.WriteLine("Rename container operation complete. Press any key to terminate the application.");
        }
