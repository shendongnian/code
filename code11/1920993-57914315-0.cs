    public MonDbBusinessComponent(IMonDbRepository monDbRepository){...}
    collection.AddScoped<IMonDbRepository>(ServiceProvider =>
    {
        string createMetaDataRecordFunctionName = Configurations.Get(LocalConfiguration, "CreateMetaDataRecordFunctionName");
        string conDbDataRecordFunctionName = Configurations.Get(LocalConfiguration, "ConDbDataRecordFunctionName");
        return new MonDbRepository(metaDataConnection, createMetaDataRecordFunctionName, conDbDataRecordFunctionName);
    });
    collection.AddScoped<IMonDbBusinessComponent, MonDbBusinessComponent>();
