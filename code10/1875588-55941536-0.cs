    public class DelegatingHandlerImpl : DelegatingHandler
    {
        public int CallCount { get; private set; }
        private readonly IWebProxy Proxy;
        private bool FirstCall = true;
        public DelegatingHandlerImpl() : base()
        {
        }
        public DelegatingHandlerImpl(HttpMessageHandler httpMessageHandler) : base(httpMessageHandler)
        {
        }
        public DelegatingHandlerImpl(IWebProxy proxy)
        {
            this.Proxy = proxy;
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            CallCount++;
            if (FirstCall && this.Proxy != null)
            {
                HttpClientHandler inner = (HttpClientHandler)this.InnerHandler;
                inner.Proxy = this.Proxy;
            }
            FirstCall = false;
            return base.SendAsync(request, cancellationToken);
        }
    }
