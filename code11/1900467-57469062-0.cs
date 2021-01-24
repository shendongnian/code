csharp
using System;
using System.Net;
namespace ProxyBot
{
    public class MyProxy : IWebProxy
    {
        public MyProxy()
        {
            //here you can load it from your custom config settings 
            this.ProxyUri = new Uri("<myProxyUrl:Port>");
        }
        public Uri ProxyUri { get; set; }
        public ICredentials Credentials { get; set; }
        public Uri GetProxy(Uri destination)
        {
            return this.ProxyUri;
        }
        public bool IsBypassed(Uri host)
        {
            //you can proxy all requests or implement bypass urls based on config settings
            return false;
        }
    }
}
# 2. Add the proxy class to `Startup.cs`
csharp
services.AddHttpClient<MyProxy>();
You may need to update your Bot.Builder packages; we've made some recent changes for proxy support.
