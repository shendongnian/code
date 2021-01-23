    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    
    class Program
    {
        static void Main()
        {
            var urls = new[] 
            { 
                "http://google.com", 
                "http://yahoo.com", 
                "http://stackoverflow.com" 
            };
            var tasks = urls
                .Select(url => Task.Factory.StartNew(
                    state => 
                    {
                        using (var client = new WebClient())
                        {
                            var u = (string)state;
                            Console.WriteLine("starting to download {0}", u);
                            string result = client.DownloadString(u);
                            Console.WriteLine("finished downloading {0}", u);
                        }
                    }, url)
                )
                .ToArray();
            Task.WaitAll(tasks);
        }
    }
