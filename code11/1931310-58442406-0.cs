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
