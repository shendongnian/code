        public class CookieAwareWebClient : WebClient
    {
        public CookieContainer CookieContainer { get; set; }
       
        public CookieAwareWebClient()
            : this(new CookieContainer())
        { }
        
        public CookieAwareWebClient(CookieContainer c)
        {
            this.CookieContainer = c;
        }
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            var castRequest = request as HttpWebRequest;
            if (castRequest != null)
            {
                castRequest.KeepAlive = true; //<-- this what you want! The rest you don't need. 
                castRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                castRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.104 Safari/537.36";
                castRequest.Referer = "https://www.jobserve.com/gb/en/Candidate/Login.aspx?url=48BB4C724EA6A1F2CADF4243A0D73C13225717A29AE8DAD6913D";
                castRequest.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
                castRequest.Headers.Add("Accept-Language", "en-GB,en-US;q=0.8,en;q=0.6");
                castRequest.CookieContainer = this.CookieContainer;
            }
            return request;
        }
    }
