    using System;
        using System.Threading;
        using System.Collections.Generic;
        using System.Net;
        using System.IO;
    
    namespace WebClientApp
    {
    class MainClassApp
    {
        private static int requests = 0;
        private static object requests_lock = new object();
    
        public static void Main() {
    
            List<string> urls = new List<string> { "http://www.google.com", "http://www.slashdot.org"};
            foreach(var url in urls) {
                ThreadPool.QueueUserWorkItem(GetUrl, url);
            }
    
            int cur_req = 0;
    
            while(cur_req<urls.Count) {
    
                lock(requests_lock) {
                    cur_req = requests; 
                }
    
                Thread.Sleep(1000);
            }
    
            Console.WriteLine("Done");
        }
    
    private static void GetUrl(Object the_url) {
    
            string url = (string)the_url;
            WebClient client = new WebClient();
            Stream data = client.OpenRead (url);
    
            StreamReader reader = new StreamReader(data);
            string html = reader.ReadToEnd ();
    
            /// Do something with html
            Console.WriteLine(html);
    
            lock(requests_lock) {
                //Maybe you could add here the HTML to SourceList
                requests++; 
            }
        }
    }
