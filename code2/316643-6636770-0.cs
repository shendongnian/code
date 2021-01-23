    using System;
    using System.Net;
    
    class Program
    {
        static void Main()
        {
            using (var client = new WebClient())
            {
                var result = client.DownloadString("http://www.google.com");
                Console.WriteLine(result);
            }
        }
    }
