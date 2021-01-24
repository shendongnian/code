    private readonly TelemetryClient _client;
    
    public FooRepository(IMongoRepositoryConfigurationManager configurationManager, TelemetryClient telemetryClient = null)
    {
    	_client = telemetryClient;
    	var url = new MongoUrl(configurationManager.MongoConnection);
    	var mongoClientSettings = MongoClientSettings.FromUrl(url);
    
    	if (_client != null)
    	{
    		mongoClientSettings.ClusterConfigurator = clusterConfigurator =>
    		{
    			clusterConfigurator.Subscribe<CommandSucceededEvent>(e =>
    			{
    				_client.TrackDependency("MongoDb", e.CommandName, e.Reply.ToString(), DateTime.Now.Subtract(e.Duration), e.Duration, true);
    			});
    			clusterConfigurator.Subscribe<CommandFailedEvent>(e =>
    			{
    				_client.TrackDependency("MongoDb", $"{e.CommandName} - {e.ToString()}", e.Failure.ToString(), DateTime.Now.Subtract(e.Duration), e.Duration, false);
    			});
    		};
    	}
    
    	var mongoClient = new MongoClient(mongoClientSettings);
    }
