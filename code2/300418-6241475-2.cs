    HttpWebRequest CreateRequest(Uri url)
    {
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Timeout = 120 * 1000;
        request.CookieContainer = _cookieContainer;
        if (UseSystemWebProxy)
        {
            var proxy = WebRequest.GetSystemWebProxy();
            if (UseDefaultCredentials)
            {
                proxy.Credentials = CredentialCache.DefaultCredentials;
            }
            if (UseNetworkCredentials != null
                && UseNetworkCredentials.Length > 0)
            {
                var networkCredential = new NetworkCredential();
                networkCredential.UserName = UseNetworkCredentials[0];
                if (UseNetworkCredentials.Length > 1)
                {
                    networkCredential.Password = UseNetworkCredentials[1];
                }
                if (UseNetworkCredentials.Length > 2)
                {
                    networkCredential.Domain = UseNetworkCredentials[2];
                }
                proxy.Credentials = networkCredential;
            }
            request.Proxy = proxy;
        }
        return request;
    }
