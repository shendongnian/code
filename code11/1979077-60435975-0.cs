    public class Program
    {
        public static async Task Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json", optional: true);
            var config = configBuilder.Build();
            var sp = new ServiceCollection()
                .AddLogging(b => b.AddConsole())
                .AddSingleton<IConfiguration>(config)
                .AddSingleton<IFooService, FooService>()
                .BuildServiceProvider();
    
            var logger = sp.GetService<ILoggerFactory>().CreateLogger<Program>();
            logger.LogDebug("Starting");
            var bar = sp.GetService<IFooService>();
            await bar.DoAsync();
        }
    }
