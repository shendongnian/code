    public class Program
    {
        public static void Main(string[] args) =>
            MainAsync(args).GetAwaiter().GetResult();
        public static async Task MainAsync(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                await new UserRoleSeed(scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>()).Seed();
            }
            
            await host.RunAsync();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
