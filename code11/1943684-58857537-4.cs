    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return WebHost.CreateDefaultBuilder(null)
                .UseStartup<TStartup>();
        }
        
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseSolutionRelativeContentRoot(Directory.GetCurrentDirectory());
            
            builder.ConfigureAppConfiguration(config =>
            {
                config.AddConfiguration(new ConfigurationBuilder()
                   //custom setting file in the test project
                    .AddJsonFile($"integrationsettings.json")
                    .Build());
            });
            
            builder.ConfigureServices(services =>
            {
            });
        }
    }
