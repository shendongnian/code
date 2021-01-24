    public class Program
        {
            public static void Main(string[] args)
            {
                var host = CreateWebHostBuilder(args).Build();
    
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    try
                    {
                        var databaseInitializer = services.GetRequiredService<IDatabaseInitializer>();
                        databaseInitializer.SeedAsync().Wait();
                    }
                    catch (Exception ex)
                    {
                    }
                }
                host.Run();
            }
    
            public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>();
        }
