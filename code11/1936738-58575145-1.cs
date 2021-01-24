    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var config = serviceProvider.GetRequiredService<IConfiguration>();
                await ApplicationDbContext.CreateAdminAccount(serviceProvider, config);
            }
            await host.RunAsync();
        }
    
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            // ...
    }
