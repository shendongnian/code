C#
public class Program
{
	public static void Main(string[] args)
	{
		CreateWebHostBuilder(args).Build().Run();
	}
	public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
		WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>()
				.ConfigureAppConfiguration((context, config) =>
				{
					var builtConfig = config.Build();
					var persistentConfigBuilder = new ConfigurationBuilder();
					var connectionString = builtConfig["ConnectionString"];
					persistentStorageBuilder.AddPersistentConfig(connectionString);
					var persistentConfig = persistentConfigBuilder.Build();
					config.AddConfiguration(persistentConfig);
				});
}
Here - `AddPersistentConfig` is an extension method built as a library that looks like this.
public static class ConfigurationBuilderExtensions
{
    public static IConfigurationBuilder AddPersistentConfig(this IConfigurationBuilder configurationBuilder, string connectionString)
    {
          return configurationBuilder.Add(new PersistentConfigurationSource(connectionString));
    }
}
class PersistentConfigurationSource : IConfigurationSource
{
    public string ConnectionString { get; set; }
    
    public PersistentConfigurationSource(string connectionString)    
    {
           ConnectionString = connectionString;
    }
    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
         return new PersistentConfigurationProvider(new DbContext(ConnectionString));
    }
}
class PersistentConfigurationProvider : ConfigurationProvider
{
    private readonly DbContext _context;
    public PersistentConfigurationProvider(DbContext context)
    {
        _context = context;
    }
    public override void Load() 
    {
           // Using _dbContext
           // Load Configuration as valuesFromDb
           // Set Data
           // Data = valuesFromDb.ToDictionary<string, string>...
    }
}
