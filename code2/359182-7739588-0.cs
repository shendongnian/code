    class CookieAwareWebClient : WebClient
    {
        public CookieContainer Cookies { get; private set; }
        public CookieAwareWebClient()
        {
            Cookies = new CookieContainer();
        }
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address) as HttpWebRequest;
            if (request != null)
            {
                request.CookieContainer = Cookies;
                return request;
            }
            return null;
        }
    }
