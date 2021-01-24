    class Program
    {
        static string storageAccountName = "storagetest789";
        static string storageAccountKey = "G36mc********Zup3h9kzj1w==";
        static void Main(string[] args)
        {
            string match_val  = null;
            using(FileStream fileStream = File.Open(@"D:\User\Pictures\test.png",FileMode.Open))
            using(MemoryStream memoryStream = new MemoryStream()){
                fileStream.CopyTo(memoryStream);
                match_val  = Convert.ToBase64String(memoryStream.ToArray());
            }
            
            StorageCredentials storageCredentials = new StorageCredentials(storageAccountName,storageAccountKey);
            CloudStorageAccount cloudStorageAccount = new CloudStorageAccount(storageCredentials, true);
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("pub"); // For convenience, it is a public container, so I do not need to set access permission
            cloudBlobContainer.CreateIfNotExists();
            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference("test2.png");
            using(MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(match_val)))
            using(Image image = Image.FromStream(memoryStream,true,true))
            using(CloudBlobStream cloudBlobStream = cloudBlockBlob.OpenWrite()){
                image.Save(cloudBlobStream, System.Drawing.Imaging.ImageFormat.Png);
            }
            Console.WriteLine(cloudBlockBlob.Uri.AbsoluteUri);
            Console.ReadLine();
        }
    }
I did not have a base64 encoded string. So I generated one in the code. The differences were that:
1. I just opened a output stream by `cloudBlockBlob.OpenWrite()`
2. Then I used image.Save method to directly save image contents to the blob stream. 
Finally, I got an url: `https://storagetest789.blob.core.windows.net/pub/test2.png` 
And I was able to view the image in browser:
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/eyATR.png
