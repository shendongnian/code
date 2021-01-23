    class ProxySupportedHttpClientFactory : HttpClientFactory
    {
        private static readonly Uri ProxyAddress 
            = new UriBuilder("http", "YourProxyIP", 80).Uri;
        private static readonly NetworkCredential ProxyCredentials 
            = new NetworkCredential("user", "password", "domain");
    
        protected override HttpMessageHandler CreateHandler(CreateHttpClientArgs args)
        {
            return new WebRequestHandler
            {
                UseProxy = true,
                UseCookies = false,
                Proxy = new WebProxy(ProxyAddress, false, null, ProxyCredentials)
            };
        }
    }
