    public class Program
    {
        public static void Main(string[] args) =>
        MainAsync(args).GetAwaiter().GetResult();
        public static async Task MainAsync(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<TransportDbContext>();
                await DbInitializer.InitializeAync(context, services);
            }
            await host.RunAsync();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    } }
