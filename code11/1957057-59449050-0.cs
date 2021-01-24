            public ChadwickDbContext(): base(GetOptions()) {}
    
            private static DbContextOptions GetOptions()
            {
                
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                var connectionString = config["ConnectionStrings:DefaultConnection"];
                var options = new DbContextOptionsBuilder();
                options.UseSqlServer(connectionString);
                return options.Options;
            }
