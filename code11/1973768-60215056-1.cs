    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args) // Sets up the default order in which all the configurations are read
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((c, x) =>
                {
                    x.AddConfiguration(Configuration); <-------
                })
                .UseSerilog((h, c) => c.Enrich.FromLogContext().WriteTo.Sentry(s =>
                {
                    s.Dsn = new Sentry.Dsn(Configuration.GetSection("Sentry:Dsn").Value);
                    s.MinimumEventLevel = Serilog.Events.LogEventLevel.Error;
                    s.MinimumBreadcrumbLevel = Serilog.Events.LogEventLevel.Information;
                })).UseSentry(x =>
                {
                    x.IncludeRequestPayload = true;
                });
