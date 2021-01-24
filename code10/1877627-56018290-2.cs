    static class Program
    {
        private static readonly IConfiguration _configuration;
        static Program()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }
        private static void ConfigureServices(IServiceCollection isc)
        {
            isc.AddSingleton(_configuration);
            isc.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(_configuration["ConnectionStrings:MyConnection"]);
                //options .UseSqlServer(_configuration.GetConnectionString("YourConnection"));
            });
            isc.AddSingleton<TheApp>();
        }
        public static  ServiceProvider CreateServiceProvider()
        {
            // create service collection
            IServiceCollection isc = new ServiceCollection();
            ConfigureServices(isc);
            // create service provider
            return isc.BuildServiceProvider();
        }
        private static void Main(string[] args)
        {
            // create application instance and run
            using (var scope = CreateServiceProvider().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<TheApp>().Run();
                // It is said that GetRequiredService is much better than GetService.
            }
        }
    }
