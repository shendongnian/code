    public static class DbContextHelper
    {
        public static DbContextOptions<yangsoftDBContext> GetDbContextOptions()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
          return new DbContextOptionsBuilder<yangsoftDBContext>()
                .UseSqlServer(new SqlConnection(configuration.GetConnectionString("local"))).Options;
        }
    }
