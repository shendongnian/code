    private class KeyHandler : DelegatingHandler
    {
        private readonly string _escapedKey;
        public KeyHandler(string key)  : this(new HttpClientHandler(), key)
        {
        }
        public KeyHandler(HttpMessageHandler innerHandler, string key) : base(innerHandler)
        {
            // escape the key since it might contain invalid characters
            _escapedKey = Uri.EscapeDataString(key);
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // we'll use the UriBuilder to parse and modify the url
            var uriBuilder = new UriBuilder(request.RequestUri);
            // when it's empty, we simply want to set the appid query parameter
            if (string.IsNullOrEmpty(uriBuilder.Query))
            {
                uriBuilder.Query = $"appid={_escapedKey}";
            }
            // otherwise we want to append it
            else
            {
                uriBuilder.Query = $"{uriBuilder.Query}&appid={_escapedKey}";
            }
            // replace the uri in the request object
            request.RequestUri = uriBuilder.Uri;
            // make the request as normal
            return base.SendAsync(request, cancellationToken);
        }
    }
