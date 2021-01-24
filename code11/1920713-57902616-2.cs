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
                    var storageAccount = CloudStorageAccount.Parse("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                    var blockBlob = storageAccount.CreateCloudBlobClient()
                        .GetContainerReference(containerName)
                        .GetBlockBlobReference(fileName);
                    blockBlob.UploadFromStreamAsync(memoryStream);
                }
            }
            static void Main(string[] args)
            {
                //Open the file
                FileStream fileStream = new FileStream("C:\\Users\\bowmanzh\\Desktop\\Book1.xlsx", FileMode.Open);
    
                //Read the byte[] of File
                byte[] bytes = new byte[fileStream.Length];
                fileStream.Read(bytes,0,bytes.Length);
                fileStream.Close();
    
                //turn from byte[] to Stream
                Stream stream = new MemoryStream(bytes);
    
                Util.UploadFile(stream,"Book2.xlsx","test");
                Console.WriteLine("Hello World!");
                Console.ReadLine();
            }
        }
    }
