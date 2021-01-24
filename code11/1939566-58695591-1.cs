using System;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage.File;
namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Parse the connection string for the storage account.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=*************");
            // Create a CloudFileClient object for credentialed access to File storage.
            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();
            // Get a reference to the file share you created previously.
            CloudFileShare share = fileClient.GetShareReference("hurytest");
            // Get a reference to the file I have uploaded to the file share("hurytest")
            CloudFile sourceFile = share.GetRootDirectoryReference().GetFileReference("test.csv");
            // Get a reference to the blob to which the file will be copied.(I have created a container with name of "targetcontainer")
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("targetcontainer");
            //container.CreateIfNotExists();
            CloudBlockBlob destBlob = container.GetBlockBlobReference("test.csv");
            // Create a SAS for the file that's valid for 24 hours.
            // Note that when you are copying a file to a blob, or a blob to a file, you must use a SAS
            // to authenticate access to the source object, even if you are copying within the same
            // storage account.
            string fileSas = sourceFile.GetSharedAccessSignature(new SharedAccessFilePolicy()
            {
                // Only read permissions are required for the source file.
                Permissions = SharedAccessFilePermissions.Read,
                SharedAccessExpiryTime = DateTime.UtcNow.AddHours(24)
            });
            // Construct the URI to the source file, including the SAS token.
            Uri fileSasUri = new Uri(sourceFile.StorageUri.PrimaryUri.ToString() + fileSas);
            // Copy the file to the blob.
            destBlob.StartCopy(fileSasUri);
        }
    }
}
Hope it would be helpful to your problem~
  [1]: https://docs.microsoft.com/en-us/java/api/com.microsoft.azure.storage.blob._cloud_block_blob.startcopy?view=azure-java-legacy#com_microsoft_azure_storage_blob__cloud_block_blob_startCopy_final_CloudBlockBlob_
