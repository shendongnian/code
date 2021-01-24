charp
public class IntegrationTestApplicationFactory : WebApplicationFactory<Startup>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        // register services here. 
    }
}
