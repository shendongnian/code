    public DataContext CreateDbContext(string[] args) {    
        // Build config
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Relative path here"))
            .AddJsonFile("appsettings.json")
            .Build();
    
        // Get connection string
        var builder = new DbContextOptionsBuilder<DataContext>();
        var connectionString = configuration .GetConnectionString("Database:ConnectionString");
        builder.UseSqlServer(connectionString, option =>
        {
            option.MigrationsAssembly("MyDbContextAssembly");
        });
        return new DataContext(builder.Options);
    }
