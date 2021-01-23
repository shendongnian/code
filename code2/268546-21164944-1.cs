    public class WebClientEx : WebClient
    {
      private CookieContainer _cookieContainer = new CookieContainer();
      public int IntTimeout { get; set; }
    
      protected override WebRequest GetWebRequest(Uri address)
      {
        WebRequest request = base.GetWebRequest(address);
        if (request != null)
          request.Timeout = IntTimeout;
    
        if (request is HttpWebRequest)
          (request as HttpWebRequest).CookieContainer = _cookieContainer;
    
        return request;
      }
    }
