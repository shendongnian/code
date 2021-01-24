    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Blob;
    using System;
    using System.IO;
    
    namespace uploadFilesToStorage
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Lets start upload files to Azure Storage!");
    
                string folderpath = @"C:\Users\bowmanzh\Pictures\images";
                var storageAccount = CloudStorageAccount
                    .Parse("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                var myClient = storageAccount.CreateCloudBlobClient();
                var container = myClient.GetContainerReference("case");
                foreach (var filepath in Directory.GetFiles(folderpath,"*.*",SearchOption.AllDirectories)) {
                    var blockBlob = container.GetBlockBlobReference(filepath);
                    blockBlob.UploadFromFileAsync(filepath);
                }
    
                Console.ReadLine();
            }
        }
    }
