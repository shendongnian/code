    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MvcProductContext>
    {
        public MvcProductContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<MvcProductContext>();
            var connectionString = configuration.GetConnectionString("MvcProductContext");
            builder.UseSqlServer(connectionString);
            return new MvcProductContext(builder.Options);
        }
    }
