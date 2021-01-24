    public class MyAPITests
        : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Startup> _factory;
    
        public MyAPITests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
    
            var host = factory.Server.Host;
            using (var scope = host.Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var dbContext = scopedServices.GetRequiredService<MyDbContext>();
        
                dbContext.Database.EnsureCreated();
        
                new MyDbContextSeed()
                    .SeedAsync(dbContext)
                    .Wait();
            }
        }
    
        //...
    }
