    class Program
    {
        static void Main()
        {
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:2.0) Gecko/20100101 Firefox/4.0";
                var result = client.DownloadString("https://mtgox.com/code/data/getDepth.php");
                Console.WriteLine(result);
            }
        }
    }
