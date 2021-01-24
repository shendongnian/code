    class Program
    {
        static void Main(string[] args)
        {
            //your other code
            CloudBlockBlob myblob = cloudBlobContainer.GetBlockBlobReference("mytemp.txt");
    
            Console.WriteLine("in main thread: start download 111");
    
            //assume the download would take 10 minutes. 
            Task<string> s = myblob.DownloadTextAsync();            
            
            //The message will print out immediately even if the download is in progress.
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
      
    
    }
