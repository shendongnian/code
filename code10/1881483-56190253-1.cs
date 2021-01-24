    public static IWebHostBuilder CreateDefaultBuilder(string[] args)
    {
        var builder = new WebHostBuilder();
        if (string.IsNullOrEmpty(builder.GetSetting(WebHostDefaults.ContentRootKey)))
        {
            builder.UseContentRoot(Directory.GetCurrentDirectory());
        }
        if (args != null)
        {
            builder.UseConfiguration(new ConfigurationBuilder().AddCommandLine(args).Build());
        }
        builder.ConfigureAppConfiguration((hostingContext, config) =>
        {
            var env = hostingContext.HostingEnvironment;
            config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                  .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
            if (env.IsDevelopment())
            {
                var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
                if (appAssembly != null)
                {
                    config.AddUserSecrets(appAssembly, optional: true);
                }
            }
            config.AddEnvironmentVariables();
            if (args != null)
            {
                config.AddCommandLine(args);
            }
        })
        .ConfigureLogging((hostingContext, logging) =>
        {
            logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
            logging.AddConsole();
            logging.AddDebug();
            logging.AddEventSourceLogger();
        }).
        UseDefaultServiceProvider((context, options) =>
        {
            options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
        });
        ConfigureWebDefaults(builder);
        return builder;
    }
