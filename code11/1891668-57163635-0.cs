    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_loggerFactory != null)
            {
                if (Debugger.IsAttached)
                {
                    optionsBuilder.UseLoggerFactory(_loggerFactory);
                }
            }
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                 // this was the missing part
                .AddEnvironmentVariables()
                .Build();
            var connectionString = configuration.GetConnectionString("xxx");
            
            optionsBuilder.UseSqlServer(connectionString);
        }
