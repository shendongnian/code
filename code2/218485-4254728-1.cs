    var proxy = System.Net.HttpWebRequest.GetSystemWebProxy();
    
    //gets the proxy uri, will only work if the request needs to go via the proxy 
    //(i.e. the requested url isn't in the bypass list, etc)
    Uri proxyUri = proxy.GetProxy(new Uri("http://www.google.com"));
    
    Console.WriteLine(proxyUri.Host);
    Console.WriteLine(proxyUri.AbsoluteUri);
