    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public  MyContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", optional: false);
    
            var config = builder.Build();
    
            var settingsSection = config.GetSection("Settings");
            var settings = new Settings();
            settingsSection.Bind(settings);
    
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>()
                .UseSqlServer(settings.ConnectionStrings.MyConnection); // or you can use option #2 either
    
            return new MyContext(optionsBuilder.Options);
        }
    }
