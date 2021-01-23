    var proxy = System.Net.HttpWebRequest.GetSystemWebProxy();
    
    //gets the proxy uri, will only work if the request needs to go via the proxy 
    //(i.e. the requested url isn't in the bypass list, etc)
    Uri proxyUri = proxy.GetProxy(new Uri("http://www.google.com"));
    
    proxyUri.Host.Dump();        // 10.1.100.112
    proxyUri.AbsoluteUri.Dump(); // http://10.1.100.112:8080/
