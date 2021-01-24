    //you will use some way to get your connection string
    var mongoConnection = Configuration.GetConnectionString("MongoDBAtlasJaken");
    var migrationOptions = new MongoMigrationOptions
    {
        Strategy = MongoMigrationStrategy.Drop,
        BackupStrategy = MongoBackupStrategy.Collections
    };
    
    services.AddHangfire(config =>
    {
        config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170);
        config.UseSimpleAssemblyNameTypeSerializer();
        config.UseRecommendedSerializerSettings();
        config.UseMongoStorage(mongoConnection, "Hangfire",new MongoStorageOptions {   MigrationOptions = migrationOptions });
                    
    });
    services.AddHangfireServer();
