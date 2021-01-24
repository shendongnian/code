    using System;
    using System.IO;
    using Microsoft.WindowsAzure.Storage;
    
    namespace ConsoleApp7
    {
        class Program
        {
            public static class Util
            {
                public async static void UploadFile(Stream memoryStream, string fileName, string containerName)
                {
                    memoryStream.Position = 0;
                    var storageAccount = CloudStorageAccount.Parse("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                    var blockBlob = storageAccount.CreateCloudBlobClient()
                        .GetContainerReference(containerName)
                        .GetBlockBlobReference(fileName);
                    blockBlob.UploadFromStreamAsync(memoryStream);
                }
            }
            static void Main(string[] args)
            {
                FileStream fileStream = new FileStream("C:\\Users\\bowmanzh\\Pictures\\sky.jpg", FileMode.Open);
                byte[] bytes = new byte[fileStream.Length];
                fileStream.Read(bytes,0,bytes.Length);
                fileStream.Close();
                Stream stream = new MemoryStream(bytes);
                Util.UploadFile(stream,"sky.jpg","test");
                Console.WriteLine("Hello World!");
                Console.ReadLine();
            }
        }
    }
