csharp
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {
        [...]
        //services.AddSingleton<IStorage, MemoryStorage>();
        var cosmosServiceEndpoint = Configuration.GetSection("CosmosServiceEndpoint").Value;
        var cosmosDBKey = Configuration.GetSection("CosmosDBKey").Value;
        var cosmosDBDatabaseName = Configuration.GetSection("CosmosDBDatabaseName").Value;
        var cosmosDBCollectionNameUserState = Configuration.GetSection("CosmosDBCollectionNameUserState").Value;
        services.AddSingleton<IStorage>(sp => new CosmosDbStorage(new CosmosDbStorageOptions()
        {
            AuthKey = cosmosDBKey,
            CollectionId = cosmosDBCollectionNameUserState,
            CosmosDBEndpoint = new Uri(cosmosServiceEndpoint),
            DatabaseId = cosmosDBDatabaseName,
        }));
    [...]
Just make sure your Cosmos settings are in `appsettings.json`
