    public static class MongoDbSettingsCollectionExtensions {
        public static IServiceCollection ConfigureMongoDbSettings(
                      this IServiceCollection services,
                      IConfiguration Configuration) {
          services.Configure<DataAccess.MongoDB.Contracts.AppSettings.MongoDBSettings> options =>
            {
                options.ConnectionString
                    = Configuration.GetConfigurationSection("MongoConnection:ConnectionString");
                options.Database
                    = Configuration.GetConfigurationSection("MongoConnection:Database");
            });
          return services;
        }
    }
