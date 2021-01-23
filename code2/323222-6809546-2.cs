    public class WebClientEx : WebClient
    {
        public CookieContainer Cookies { get; private set; }
        public WebClientEx()
        {
            Cookies = new CookieContainer();
        }
    
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = (HttpWebRequest)base.GetWebRequest(address);
            request.CookieContainer = Cookies;
            return request;
        }
    }
