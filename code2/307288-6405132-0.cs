    using System;
    using System.Net;
    using System.Web;
    
    class Program
    {
        static void Main()
        {
            using (var client = new WebClient())
            {
                var newUri = new Uri("http://proxy.foo.com/");
                var myProxy = new WebProxy();
                myProxy.Credentials = CredentialCache.DefaultCredentials;
                myProxy.Address = newUri;
                client.Proxy = myProxy;
    
                var query = HttpUtility.ParseQueryString(string.Empty);
                query["q"] = "info:http://www.yahoo.com";
                var url = new UriBuilder("http://www.google.com/search");
                url.Query = query.ToString();
                Console.WriteLine(client.DownloadString(url.ToString()));
            }
        }
    }
