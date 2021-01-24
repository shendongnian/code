    public class CustomHttpClientFactory : DefaultHttpClientFactory
    {
        public bool? AutoRedirect { get; set; }
        public Proxy Proxy { get; set; }
        public override HttpMessageHandler CreateMessageHandler()
        {
            var handler = new HttpClientHandler();
            if (AutoRedirect != null)
                handler.AllowAutoRedirect = AutoRedirect;
            if (Proxy != null) {
                handler.Proxy = new WebProxy { ... };
                handler.UseProxy = true;
            }
            return handler;
        }
    }
