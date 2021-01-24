    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)            
        .ConfigureAppConfiguration(b => {
                b.AddEnvironmentVariables();
                var connectionString = b.Build().GetConnectionString("MyDatabase");
                .AddMyCustomConfiguration(o => o.UseSqlServer(connectionString));
        })              
        .UseStartup<Startup>();
