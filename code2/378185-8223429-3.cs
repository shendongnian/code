    class Downloader
    {
        static void Main(string[] args)
        {
            NetworkCredential nc = new NetworkCredential(args[0], args[1]);
            WebProxy proxy = new WebProxy(args[2], false);
            proxy.Credentials = nc;
            WebRequest request = new WebRequest(args[3]);
            request.Proxy = proxy;
            using (WebResponse response = request.GetResponse())
            {
                Console.WriteLine(
                    @"{0} - {1} bytes",
                    response.ContentType,
                    response.ContentLength);
            }
        }
    }
