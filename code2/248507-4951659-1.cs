    public class CookieMonsterWebClient : WebClient
    {
        public CookieContainer Cookies { get; set; }
    
        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
            request.CookieContainer = Cookies;
            return request;
        }
    }
