    new ServiceCollection()
    .AddTransient(provider => {
                    var options = new DbContextOptionsBuilder<MyDbContext>()
                    .EnableSensitiveDataLogging(true)
                    .UseLoggerFactory((ILoggerFactory)provider.GetService(typeof(ILoggerFactory)))
                    .UseMySql(config.GetConnectionString("DefaultConnection"))
                        .Options;
                    return new MyDbContext(options);
                })
