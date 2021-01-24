    public static class MongoDbSettingsCollectionExtensions {
        public static IServiceCollection ConfigureMongoDbSettings(
                      this IServiceCollection services,
                      IConfiguration Configuration) {
          services.Configure<DataAccess.MongoDB.Contracts.AppSettings.MongoDBSettings> options =>
            {
                options.ConnectionString
                    = GetConfigurationSection("MongoConnection:ConnectionString");
                options.Database
                    = GetConfigurationSection("MongoConnection:Database");
            });
          return services;
        }
    }
