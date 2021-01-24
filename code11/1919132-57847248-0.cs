    using System;
    using System.Diagnostics;
    using System.Threading;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Blob;
    using Microsoft.Azure.Storage.DataMovement;
    using Microsoft.Azure.Storage.File;
    
    namespace AzureDataMovementTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                string storageConnectionString = "xxxx";
                CloudStorageAccount account = CloudStorageAccount.Parse(storageConnectionString);
    
                CloudFileClient fileClient = account.CreateCloudFileClient();
                CloudFileShare fileShare = fileClient.GetShareReference("t22");
                fileShare.CreateIfNotExists();
    
                CloudFileDirectory fileDirectory= fileShare.GetRootDirectoryReference();
    
                //here, I want to upload all the files and subfolders in the follow path.
                string source_path = @"F:\temp\1";
    
                //if I want to upload the folder 1, then use the following code to create a file directory in azure.
                CloudFileDirectory fileDirectory_2 = fileDirectory.GetDirectoryReference("1");
                fileDirectory_2.CreateIfNotExists();
    
                
                
                UploadDirectoryOptions directoryOptions = new UploadDirectoryOptions
                {
                    Recursive = true
                };
    
                var task = TransferManager.UploadDirectoryAsync(source_path,fileDirectory_2,directoryOptions,null);
                task.Wait();
    
                Console.WriteLine("the upload is completed");
                Console.ReadLine();
            }
    
        }
    }
