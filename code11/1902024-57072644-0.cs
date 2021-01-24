public class Startup
{
    private readonly IConfiguration _configuration;
    public Startup(IHostingEnvironment env)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
        _configuration = builder.Build();
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<DBConfigurationOptions>(_configuration.GetSection("DBConfiguration"));
    }
}
and then it's injected as:
public class DBContext : DbContext
{
    private readonly DBConfigurationOptions_dBConfiguration;
    public DBContext(IOptions<DBConfigurationOptions> dBConfiguration)
    {
        _dBConfiguration = dBConfiguration.Value;
    }
}
