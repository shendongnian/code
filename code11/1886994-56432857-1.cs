    public class Program
    {
        private static string _parameterStoreNamePath;
        public static void Main(string[] args)
        {
            _parameterStoreNamePath = Environment.GetEnvironmentVariable("AWS_PARAMETER_STORE_NAME");
            CreateWebHostBuilder(args).Build().Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                      .ConfigureAppConfiguration(builder =>
                      {
                          builder.AddSystemsManager(_parameterStoreNamePath); 
                      })
                      .UseStartup<Startup>();
        }
    }
