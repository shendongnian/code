    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace UploadAzureBlob.Services
    {
        public class BlobManager : IBlobManager
        {
            private CloudBlobClient cloudBlobClient;
            public BlobManager()
            {
                // Retrieve the connection string for blob storage
                string storageConnectionString = "";
    
                CloudStorageAccount.TryParse(storageConnectionString, out CloudStorageAccount storageAccount);
    
                // Create the CloudBlobClient that represents the Blob storage endpoint for the storage account.
                cloudBlobClient = storageAccount.CreateCloudBlobClient();
            }
    
            /// <summary>
            /// Uploads a file to blob storage.
            /// </summary>
            /// <param name="fileName"></param>
            /// <param name="file"></param>
            /// <returns></returns>
            public async Task<string> UploadFileToBlobAsync(string fileName, Stream stream)
            {
                try
                {
                    // Create a container.
                    CloudBlobContainer blobContainer = cloudBlobClient.GetContainerReference("test");
                    await blobContainer.CreateAsync();
    
                    BlobContainerPermissions perm = await blobContainer.GetPermissionsAsync();
                    perm.PublicAccess = BlobContainerPublicAccessType.Container;
                    await blobContainer.SetPermissionsAsync(perm);
    
                    // Get a reference to the blob address, then upload the file to the blob.
                    var cloudBlockBlob = blobContainer.GetBlockBlobReference(fileName);
                    await cloudBlockBlob.UploadFromStreamAsync(stream);
    				
    				// Returning the URI of the freshly created resource
                    return cloudBlockBlob.Uri.ToString();
                }
                catch (StorageException ex)
                {
    				throw;
                }
            }
        }
    }
