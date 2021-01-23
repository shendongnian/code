    class Program
    {
        public static void Main()
        {
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.2.13) Gecko/20101203 Firefox/3.6.13";
                string result = client.DownloadString("http://www.thehut.com/blu-ray/harry-potter-collection-years-1-6/10061821.html");
                Console.WriteLine(result);
            }
        }
    }
