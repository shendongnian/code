    public class Program
    {
        public static void Main(string[] args)
        {
            // create web host
            var host = CreateWebHostBuilder(args).Build();
            // create service scope for seeding the database
            using (var scope = host.Services.CreateScope())
            {
                // retrieve the sample data service
                var sampleData = scope.ServiceProvider.GetRequiredService<ISampleData>();
                // run your sample data initialization
                _sampleData.Initialize();
            }
            // run the application
            host.Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
            => WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
