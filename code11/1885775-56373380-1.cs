            static void Main(string[] args)
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse("xxxx");
    
                var blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = blobClient.GetContainerReference("f22");
                CloudBlockBlob myblob = cloudBlobContainer.GetBlockBlobReference("mytemp.txt");
    
                Console.WriteLine("in main thread: start download 111");
    
                string s = myblob.DownloadText();            
                
                //if the download takes 10 minutes, then the following message will be printed out after 10 minutes.
                Console.WriteLine("in main thread 222!");  
                    
                Console.ReadLine();
            }
