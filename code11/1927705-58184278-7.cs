    public class Program {
        public static void Main(string[] args) {
            CreateHostBuilder(args).Build().Run();
        }
    
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) => {
                    IConfiguration configuration = new ConfigurationBuilder()
                        .SetBasePath(Path.Combine(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();
                    WorkerOptions options = configuration.GetSection("WCF").Get<WorkerOptions>();
                    
                    services.AddSingleton(options);
                    services.AddHostedService<Worker>();
                });
    }
