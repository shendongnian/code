    MongoConnection connection = new MongoConnection();
    MongoDBClientConnection clientConnection = new MongoDBClientConnection(){MongoDBClient = new MongoClient( MongoClientSettings settings = new MongoClientSettings
                {
                    Server = new MongoServerAddress(localhost, 5477)                
                };)}        
    connection.MongoDBServer = clientConnection.MongoDBClient.GetServer();
    connection.MongoDBServer.Connect();
