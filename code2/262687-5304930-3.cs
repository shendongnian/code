    public static Uri UrlOriginal(this HttpRequestBase request)
    {
      string hostHeader = request.Headers["host"];
             
      return new Uri(string.Format("{0}://{1}{2}",
         request.Url.Scheme, 
         hostHeader, 
         request.RawUrl));
    }
