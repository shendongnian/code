    using Microsoft.Azure.Storage.Auth;
    using Microsoft.Azure.Storage.Blob;
    using System;
    
    namespace AzureStorageTest
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                string storageAccountName = "<storage account name>";
                string containerName = "<container name>";
                string sasToken = "<sas token>";
                StorageCredentials creds;
                CloudBlobContainer cloudBlobContainer;
                creds = new StorageCredentials(sasToken);
    
                cloudBlobContainer = new CloudBlobContainer(new Uri("https://"+ storageAccountName + ".blob.core.windows.net/"+ containerName), creds);
                BlobContinuationToken blobContinuationToken = null;
                var blobs = cloudBlobContainer.ListBlobsSegmented("", blobContinuationToken);
                foreach (var blob in blobs.Results) {
                    Console.WriteLine(blob.Uri);
                }
    
                Console.ReadKey();
            }
        }
    }
