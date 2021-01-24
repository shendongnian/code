    /// <summary>This service should be registered as a singleton, or otherwise have an unbounded lifetime.</summary>
    public QuickAndDirtyHttpClientFactory : IHttpClientFactory // `IHttpClientFactory ` can be your own interface. You do NOT need to use `Microsoft.Extensions.Http`.
    {
        private readonly HttpClientHandlerPool pool = new HttpClientHandlerPool();
        public HttpClient CreateClient( String name )
        {
            PooledHttpClientHandler pooledHandler = new PooledHttpClientHandler( name, this.pool );
            return new HttpClient( pooledHandler );
        }
        // Alternative, which allows consumers to set up their own DelegatingHandler chains without needing to configure them during DI setup.
        public HttpClient CreateClient( String name, Func<HttpMessageHandler, DelegatingHandler> createHandlerChain )
        {
            PooledHttpClientHandler pooledHandler = new PooledHttpClientHandler( name, this.pool );
            DelegatingHandler chain = createHandlerChain( pooledHandler );
            return new HttpClient( chain );
        }
    }
    internal class HttpClientHandlerPool
    {
        public HttpClientHandler BorrowHandler( String name )
        {
            // Implementing this is an exercise for the reader.
            // Alternatively, I'm available as a consultant for a very high hourly rate :D
        }
        public void ReleaseHandler( String name, HttpClientHandler handler )
        {
            // Implementing this is an exercise for the reader.
        }
    }
    internal class PooledHttpClientHandler : HttpMessageHandler
    {
        private readonly String name;
        private readonly HttpClientHandlerPool pool;
        public PooledHttpClientHandler( String name, HttpClientHandlerPool pool )
        {
            this.name = name;
            this.pool = pool ?? throw new ArgumentNullException(nameof(pool));
        }
        protected override async Task<HttpResponseMessage> SendAsync( HttpRequestMessage request, CancellationToken cancellationToken )
        {
            HttpClientHandler handler = this.pool.BorrowHandler( this.name );
            try
            {
                return await handler.SendAsync( request, cancellationToken ).ConfigureAwait(false);
            }
            finally
            {
                this.pool.ReleaseHandler( this.name, handler );
            }
        }
    }
