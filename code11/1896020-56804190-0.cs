    private static DocumentClient client = GetCustomClient();
    private static DocumentClient GetCustomClient()
    {
        DocumentClient customClient = new DocumentClient(
            new Uri(ConfigurationManager.AppSettings["CosmosDBAccountEndpoint"]), 
            ConfigurationManager.AppSettings["CosmosDBAccountKey"],
            new ConnectionPolicy
            {
                ConnectionMode = ConnectionMode.Direct,
                ConnectionProtocol = Protocol.Tcp,
                // Customize retry options for Throttled requests
                RetryOptions = new RetryOptions()
                {
                    MaxRetryAttemptsOnThrottledRequests = 10,
                    MaxRetryWaitTimeInSeconds = 30
                }
            });
    
        // Customize PreferredLocations
        customClient.ConnectionPolicy.PreferredLocations.Add(LocationNames.CentralUS);
        customClient.ConnectionPolicy.PreferredLocations.Add(LocationNames.NorthEurope);
    
        return customClient;
    }
    
    [FunctionName("CosmosDbSample")]
    public static async Task<HttpResponseMessage> Run(
