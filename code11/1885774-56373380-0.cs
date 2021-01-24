    class Program
    {
        static void Main(string[] args)
        {
            //your other code
            CloudBlockBlob myblob = cloudBlobContainer.GetBlockBlobReference("mytemp.txt");
    
            Console.WriteLine("in main thread: start download 111");
    
            Task<string> s = myblob.DownloadTextAsync();            
            
            //the message will print out immediately even if the download is in progress.
            Console.WriteLine("in main thread 222!");
            
            //use this code to check if the download complete or not
            while (!s.IsCompleted)
            {
                Console.WriteLine("not completed");
                System.Threading.Thread.Sleep(2000);
            }
    
            Console.WriteLine("the string length in MB: "+s.Result.Length/1024/1024);
    
            Console.ReadLine();
        }
    
        //assume the file is large, like 10M or more
        static async Task<string> MyDownloadTextAsync(CloudBlockBlob blob)
        {
            string mytext = await blob.DownloadTextAsync();
            
            return mytext;
        }
    
    }
