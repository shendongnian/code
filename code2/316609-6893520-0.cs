    public class WebClient2 : WebClient
    {
      [SecurityCritical]
      public WebClient2() : base() { }  
      protected override WebRequest GetWebRequest(System.Uri address)
      {
        var wr = base.GetWebRequest(address);
        if (wr is HttpWebRequest)
          (wr as HttpWebRequest).AllowAutoRedirect = false;
        return wr;
      }
    }
