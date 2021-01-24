    public class TestApiWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        private readonly HttpClient _identityServerClient;
        public TestApiWebApplicationFactory(HttpClient identityServerClient)
        {
            _identityServerClient = identityServerClient;
        }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
            builder.ConfigureServices(
                s =>
                {
                    s.AddSingleton<IConfigureOptions<JwtBearerOptions>>(services =>
                    {
                        return new TestJwtBearerOptions(_identityServerClient);
                    });
                });
        }
    }
