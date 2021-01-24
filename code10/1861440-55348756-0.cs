    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Auth;
    using System;
    
    namespace AzureFileTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Program p = new Program();
                p.SaveText("file1"); //in the first call, file1 created and text uploads.
                p.SaveText("file2"); //in the second call, file2 created and text uploads.         
                          
                Console.WriteLine("done now");
                Console.ReadLine();
            }
    
    
            public void SaveText(string fileName)
            {
                string accountName = "xxxxx";
                string key = "xxxxxx";
    
                var storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, key), true);
                var share = storageAccount.CreateCloudFileClient().GetShareReference("test");
                share.CreateIfNotExistsAsync().Wait();
    
                var root = share.GetRootDirectoryReference();
                root.GetFileReference(fileName).UploadTextAsync("mytext").Wait();
            }
    
        }
    }
