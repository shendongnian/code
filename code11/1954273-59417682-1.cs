charp
public class IntegrationTestApplicationFactory : WebApplicationFactory<Startup>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        // register services here. 
        // or in the ConfigureWebHost method
    }
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddTransient<YourServiceType>();
        }
    }
}
