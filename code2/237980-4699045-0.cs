    using System;
    using System.Net;
    
    class Test
    {    
        static void Main()
        {
            WebClient client = new WebClient();
            for (int i = 0; i < 50; i++)
            {
                string text = client.DownloadString("http://www.microsoft.com");
                Console.WriteLine(text.Length);
            }
        }
    }
