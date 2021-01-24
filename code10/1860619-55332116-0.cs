    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    
    namespace ConsoleApp4netcore
    {
        class Program
        {
            static void Main(string[] args)
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse("xxxxx");
    
                var blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = blobClient.GetContainerReference("test-1");
                CloudBlobDirectory directory = cloudBlobContainer.GetDirectoryReference("sub1");
                foreach (IListBlobItem blobItem in directory.ListBlobsSegmentedAsync(null).Result.Results)
                {
                    if (blobItem is CloudBlockBlob blob)
                    { 
                        //the new package supports syncronous method
                        blob.FetchAttributes();
    
                        foreach (var metadataItem in blob.Metadata)
                        {
                        Console.WriteLine("\tKey: {0}", metadataItem.Key);
                        Console.WriteLine("\tValue: {0}", metadataItem.Value);
                        }
                    }
    
                }            
                
                Console.ReadLine();
            }
        }
    }
