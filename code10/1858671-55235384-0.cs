    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.File;
    using System;
    
    namespace MyConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                Program p = new Program();
                string azureFileName = "1.zip";
                string localFileName = @"D:\1.zip";
    
                Console.WriteLine("start upload..");
    
                p.UploadFileFromFile(azureFileName, localFileName);
    
                Console.WriteLine("completed**");
                Console.ReadLine();
            }
    
            public void UploadFileFromFile(string azureFileName, string localFileName)
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse("xxxx");
                CloudFileClient client = storageAccount.CreateCloudFileClient();
                CloudFileShare share = client.GetShareReference("testfolder");
                CloudFileDirectory dir = share.GetRootDirectoryReference();
                CloudFile fileReference = dir.GetFileReference(azureFileName);
                Console.WriteLine("going to upload");
                fileReference.UploadFromFile(localFileName);
            }
        }
    }
