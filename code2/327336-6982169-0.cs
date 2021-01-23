    WebService WS = new WebService();
    WS.Proxy = wwwproxy("http://someproxy:8080";
    
    
    
      WebProxy wwwproxy(string ptProxyURI) 
    {
            var aProxy = New WebProxy;
            aProxy.Credentials = CredentialCache.DefaultCredentials;
            aProxy.BypassProxyOnLocal = True;
            aProxy.Address = New Uri(ptProxyURI);
            Return aProxy;
    }
