    //...ConfigureServices
    services.AddScoped<IMongoDatabase>(sp => {
        var dbParams = sp.GetRequiredService<IDatabaseParameters>();
        var client = new MongoClient(dbParams.ConnectionString);
        return client.GetDatabase(dbParams.DatabaseName);
    });
    //...
