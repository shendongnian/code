        //using Azure.Storage.Blobs;
        //using Azure.Storage.Blobs.Models;
        private static void GetContainerLastModified()
        {
            BlobContainerClient container = new BlobContainerClient(connectionString, "container1");
            BlobContainerProperties properties = container.GetProperties();
            Console.WriteLine(properties.LastModified);
        }
        private static void GetBlobLastModified()
        {
            BlobClient blob = new BlobClient(connectionString, "container1", "file1.txt");
            BlobProperties properties = blob.GetProperties();
            
            Console.WriteLine(properties.LastModified);
        }
