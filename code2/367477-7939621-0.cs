    using System;
    using System.Net;
    
    class Test
    {
        static void Main()
        {
            WebClient client = new WebClient();
            client.DownloadFile("http://wordpress.org/latest.zip",
                                "latest.zip");
        }
    }
