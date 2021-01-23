    namespace ProxyTester
    {
    class Program
    {
        static void Main(string[] args)
        {
            var htmlResponse = new StringBuilder();
            var RequestPage = BuildHttpRequest("https://google.com/");
            GetHttpResponse(RequestPage, htmlResponse);
        }
        public static HttpWebRequest BuildHttpRequest(string url)
        {
            try
            {
                var getPage = (HttpWebRequest)WebRequest.Create(url);
                WebProxy proxyHTTP = new WebProxy("201.38.194.50", 53128);
                getPage.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                getPage.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.2.19) Gecko/20110707 Firefox/3.6.19";
                getPage.ProtocolVersion = HttpVersion.Version11;
                getPage.Method = "GET";
                getPage.Proxy = proxyHTTP;
                getPage.Timeout = 10000;
                getPage.ReadWriteTimeout = 10000;
                return getPage;
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }
        public static bool GetHttpResponse(HttpWebRequest page,  StringBuilder htmlResponse)
        {
            htmlResponse.Length = 0; 
            try
            {
                Console.WriteLine("A");
               // var pageResponse = page.GetResponse();
                page.Timeout = 10000;
                var pageResponse = (HttpWebResponse)page.GetResponse();
                Console.WriteLine("5 minutes!");
                if (pageResponse.StatusCode == HttpStatusCode.OK)
                {
                   
                    var reader = new StreamReader(pageResponse.GetResponseStream());
                    htmlResponse.Append(reader.ReadToEnd());
                    pageResponse.Close();
                    reader.Close();
                    return true;
                }
                Console.WriteLine(pageResponse.StatusCode.ToString());
                pageResponse.Close();
                return false;
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }
    }
}
