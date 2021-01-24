    public class Program {
        public static void Main(string[] args) {
            CreateWebHostBuilder(args).Build().Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) {
            return WebHost.CreateDefaultBuilder(args)
                      .ConfigureAppConfiguration(builder => {
                          builder.AddSystemsManager("/AppName");
                      })
                      .UseStartup<Startup>();
        }
    }
