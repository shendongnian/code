    private static void ReplicateCookies(HttpWebRequest request)
    {
        if (HttpContext.Current == null)
            return;
        if (request.CookieContainer == null)
            request.CookieContainer = new CookieContainer();
        foreach (var cookieKey in HttpContext.Current.Request.Cookies.Keys)
        {
            if (!cookieKey.ToString().Equals("ASP.NET_SessionId"))
            {
                var cookie = HttpContext.Current.Request.Cookies[cookieKey.ToString()];
                request.CookieContainer.Add(new Cookie(cookie.Name, cookie.Value, cookie.Path, string.IsNullOrEmpty(cookie.Domain)
                    ? HttpContext.Current.Request.Url.Host
                    : cookie.Domain));
            }
                    
        }
    }
    private HttpWebRequest CreateRequest(string url, string method = null)
    {
        var httpRequest = WebRequest.Create(url) as HttpWebRequest;
        ReplicateCookies(httpRequest);
        httpRequest.KeepAlive = false;
        httpRequest.Method = method ?? "GET";
        httpRequest.Timeout = 20000;
        httpRequest.Proxy = null;
        httpRequest.ServicePoint.ConnectionLeaseTimeout = 20000;
        httpRequest.ServicePoint.MaxIdleTime = 10000;
        httpRequest.Headers.Add("Accept-Language", Thread.CurrentThread.CurrentCulture.Name);
        return httpRequest;
    }
    public string ReadWebPage(string url)
    {
        string result;
        var httpRequest = CreateRequest(url);
        try
        {
            using (var httpResponse = httpRequest.GetResponse())
            {
                using (var stream = httpResponse.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        result = reader.ReadToEnd();
                        reader.Close();
                    }
                    stream.Flush();
                    stream.Close();
                }
                httpResponse.Close();
            }
        }
        finally
        {
            httpRequest.Abort();
        }
        return result;
    }
