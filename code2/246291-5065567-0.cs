    using System.Net;
    Uri exampleUri = new Uri("http://www.example.org/")
    IWebProxy defaultProxy = WebRequest.GetSystemWebProxy();
    bool isBypassed = defaultProxy.IsBypassed(exampleUri);  // ... false
    Uri proxyUri = defaultProxy.GetProxy(exampleUri);   // ... http://10.96.4.254:8080/someproxy.mycorp.example:8080
