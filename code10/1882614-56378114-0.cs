    client = new MongoClient("mongodb://localhost");
    database = client.GetDatabase(mongoDbStr);
    bool isMongoLive = database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(1000);
    
    if(isMongoLive)
    {
        // connected
    }
    else
    {
        // couldn't connect
    }
