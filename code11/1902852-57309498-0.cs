    public void ConfigureServices(IServiceCollection services)
            {
                ...
                
                var config = new CosmosDbStorageOptions
                {
                    AuthKey = CosmosDBKey,
                    CollectionId = CosmosDBAntoherCollectionName,
                    CosmosDBEndpoint = new Uri(CosmosServiceEndpoint),
                    DatabaseId = CosmosDBDatabaseName,
                };
                var transcriptMiddleware = new TranscriptLoggerMiddleware(new CosmosTranscriptStore(config));
                services.AddSingleton(transcriptMiddleware);
                
                ...
            }
