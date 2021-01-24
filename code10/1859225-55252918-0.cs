    services.AddDbContext<MyContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(connectionString);
                options.UseInternalServiceProvider(serviceProvider);
            }, ServiceLifetime.Singleton); // <-- Here it is
