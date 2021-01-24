    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var serviceCollection = new ServiceCollection()
                .AddEntityFrameworkSqlServer();
            
			serviceCollection = serviceCollection.AddSingleton<IModelCustomizer, YourModelCustomizer>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            optionsBuilder
                .UseInternalServiceProvider(serviceProvider);
        }
