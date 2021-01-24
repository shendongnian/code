    // ===== NOT USING ANYMORE =====
    // using (var scope = Container.BeginLifetimeScope())
    // { // Building and killing the container just to get already defined ILogger from Core library.
        // var zLogger = scope.Resolve<IZLogger>(); // Registered in Core library.
        // Log.Logger = zLogger.GetCurrentClassLogger<Program>();
    // }
    // ===== NOT USING ANYMORE =====
    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
              .ConfigureServices(services => services.AddAutofac())
              .UseStartup<Startup>()
              .UseSerilog(); // Added this line as per docs
