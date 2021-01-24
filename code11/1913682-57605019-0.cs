        private  DocumentClient GetDocumentClient( CosmosDbConnectionOptions configuration)
            {
                            _documentClient = new DocumentClient(
                                  new Uri(configuration.Endpoint),
                                  configuration.AuthKey,
                                  new ConnectionPolicy(){ 
                                  IdleTcpConnectionTimeout = new TimeSpan(0,0,10,0) 
                                   });
                            //create database if not exists
                            _documentClient.CreateDatabaseIfNotExistsAsync(new Database { Id = configuration.Database });
                            return _documentClient;
            }
