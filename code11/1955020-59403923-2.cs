    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Auth;
    using Microsoft.Azure.Storage.File;
    using System;
    
    namespace AzureFileTest2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string accountName = "xxx";
                string accountKey = "xxx";
                CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
    
                CloudFileClient cloudFileClient = storageAccount.CreateCloudFileClient();
    
                //make sure the file share named test1 exists.
                CloudFileShare fileShare = cloudFileClient.GetShareReference("test1");
                CloudFileDirectory fileDirectory = fileShare.GetRootDirectoryReference();
                CloudFile myfile = fileDirectory.GetFileReference("test123.txt");
    
                if (!myfile.Exists())
                {
                    //if the file does not exists, then create the file and set the file max size to 100kb.
                    myfile.Create(100 * 1024 * 1024);                
                }
    
                //upload text to the file
                //Besides using UploadText() method to directly upload text, you can also use UploadFromFile() / UploadFromByteArray() / UploadFromStream() methods as per your need.
                myfile.UploadText("hello, it is using azure storage SDK");
    
                Console.WriteLine("**completed**");
                Console.ReadLine();
            }
        }
    }
