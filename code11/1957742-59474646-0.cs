    public static class BootstrapCosmosDbClient {
    
        private static event EventHandler initializeDatabase = delegate { };
        public static IServiceCollection AddCosmosDbServiceAsync(this IServiceCollection services) {
        
            Func<IServiceProvider, ICosmosDbService> factory = (sp) => {
                //resolve configuration
                IConfiguration configuration = sp.GetService<IConfiguration>();
                //and get the configured settings (Microsoft.Extensions.Configuration.Binder.dll)
                CosmosDbClientSettings cosmosDbClientSettings = configuration.Get<CosmosDbClientSettings>();
                string databaseName = cosmosDbClientSettings.CosmosDbDatabaseName;
                string containerName = cosmosDbClientSettings.CosmosDbCollectionName;
                string account = cosmosDbClientSettings.CosmosDbAccount;
                string key = cosmosDbClientSettings.CosmosDbKey;
                
                CosmosClientBuilder clientBuilder = new CosmosClientBuilder(account, key);
                CosmosClient client = clientBuilder.WithConnectionModeDirect().Build();
                CosmosDbService cosmosDbService = new CosmosDbService(client, databaseName, containerName);
                
                //async event handler
                EventHandler handler = null;
                handler = async (sender, args) => {
                    initializeDatabase -= handler; //unsubscribe
                    DatabaseResponse database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
                    await database.Database.CreateContainerIfNotExistsAsync(containerName, "/id");
                    
                };
                initializeDatabase += handler; //subscribe
                initializeDatabase(null, EventArgs.Empty); //raise the event to initialize db
                
                return cosmosDbService;
            };
            services.AddSingleton<ICosmosDbService>(factory);
            return service;
        }
    }
    
