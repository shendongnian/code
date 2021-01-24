    public static void Main(string[] args)
        {
          try
          {
            var iWebHost = CreateWebHostBuilder(args).Build();
            var path = Directory.GetCurrentDirectory();
            var configuration = new ConfigurationBuilder()
              .SetBasePath(path)
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .AddJsonFile($"appsettings.{_environmentName}.json", optional: false, reloadOnChange: true)
            .Build();
    
            var logger = new LoggerConfiguration()
              .Enrich.FromLogContext()
              .ReadFrom.Configuration(configuration)
              .CreateLogger();
    
            Log.Logger = logger;
            Log.Information("Application starting");
            iWebHost.Run();
          }
          catch(Exception exception)
          {
            Log.Error(exception.ToString());
          }
          finally
          {
            Log.CloseAndFlush();
          }
        }
