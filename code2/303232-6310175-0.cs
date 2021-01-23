    public class CookiesAwareWebClient : WebClient
    {
        public CookieContainer CookieContainer { get; private set; }
    
        public CookiesAwareWebClient()
        {
            CookieContainer = new CookieContainer();
        }
    
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            ((HttpWebRequest)request).CookieContainer = CookieContainer;
            return request;
        }
    }
    
    class Program
    {
        static void Main()
        {
            using (var client = new CookiesAwareWebClient())
            {
                var values = new NameValueCollection
                {
                    { "userName", "user" },
                    { "password", "password" },
                    { "x", "0" }, // <- I doubt the server cares about the x position of where the user clicked on the image submit button :-)
                    { "y", "0" }, // <- I doubt the server cares about the y position of where the user clicked on the image submit button :-)
                    { "login", "login" },
                };
                // We authenticate first
                client.UploadValues("http://example.com/login", values);
                // Now we can download
                client.DownloadFile("http://example.com/abc.tgz", @"c:\abc.tgz");
            }
        }
    }
