            services.AddDataProtection().ProtectKeysWithDpapi(protectToLocalMachine: true);
            services.AddDataProtection()
                .ProtectKeysWithCertificate(
                    new X509Certificate2(Path.Combine(Directory.GetCurrentDirectory(), "clientCert.pfx"), "password",
                     X509KeyStorageFlags.MachineKeySet
                             | X509KeyStorageFlags.PersistKeySet
                             | X509KeyStorageFlags.Exportable)
                )
                .UnprotectKeysWithAnyCertificate(
                    new X509Certificate2(Path.Combine(Directory.GetCurrentDirectory(), "clientCert.pfx"), "password",
                                X509KeyStorageFlags.MachineKeySet
                             | X509KeyStorageFlags.PersistKeySet
                             | X509KeyStorageFlags.Exportable
                    )
                );
            services.Configure<StorageConfiguration>(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build());
            var redisConf = Configuration.GetSection("RedisConnection").Get<RedisConnection>();
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(redisConf.Host.ToString() + ":" + redisConf.Port.ToString());
            services.AddDataProtection().PersistKeysToStackExchangeRedis(redis, "DataProtection-Keys");
            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConf.Host.ToString() + ":" + redisConf.Port.ToString()));
