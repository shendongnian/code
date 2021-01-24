    public class HttpServer
    {
        private readonly IContainer rootContainer;
        public HttpServer()
        {
            this.rootContainer = RegisterServices( new ContainerBuilder() ).Build();
            
        }
        private static IContainerBuilder RegisterServices( IContainerBuilder services )
        {
            return services
                .RegisterSingleton<ISystemClock,BiosBlock>()
                .RegisterTransient<IDbConnection>( factory: return new SqlConnection() )
                .RegisterRequest<RequestTracingService>();
        }
        public void OnHttpRequest( Socket socket )
        {
            HttpContext context = new HttpContext();
            context.RequestContainer = this.rootContainer.CreateChildContainer();
            try
            {
                // hand-off the `context` object to code that reads the request, does processing, and then writes the response
            }
            finally
            {
                context.RequestContainer.Dispose(); // <-- this disposes of any objects created by RequestContainer during the processing of the request, without touching any objects created by `rootContainer`.
            }
        }
    }
