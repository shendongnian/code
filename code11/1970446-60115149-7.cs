    public static IWebHostBuilder UseLogging(this IWebHostBuilder webHostBuilder, string applicationName = null) =>
        webHostBuilder
            .UseSetting("suppressStatusMessages", "True") // disable startup logs
            .UseSerilog((context, loggerConfiguration) =>
            {
                var logLevel = context.Configuration.GetValue<string>("Logging:MinimumLevel"); // read level from appsettings.json
                if (!Enum.TryParse<LogEventLevel>(logLevel, true, out var level))
                {
                    level = LogEventLevel.Information; // or set default value
                }
    
                // get application name from appsettings.json
                applicationName = string.IsNullOrWhiteSpace(applicationName) ? context.Configuration.GetValue<string>("App:Name") : applicationName;
    
                loggerConfiguration.Enrich
                    .FromLogContext()
                    .MinimumLevel.Is(level)
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                    .MinimumLevel.Override("System", LogEventLevel.Warning)
                    .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                    .Enrich.WithProperty("ApplicationName", applicationName);
    
                // read other Serilog configuration
                loggerConfiguration.ReadFrom.Configuration(context.Configuration);
    
                // get output format from appsettings.json. 
                var outputFormat = context.Configuration.GetValue<string>("Logging:OutputFormat");
                switch (outputFormat)
                {
                    case "elasticsearch":
                        loggerConfiguration.WriteTo.Console(new ElasticsearchJsonFormatter());
                        break;
                    default:
                        loggerConfiguration.WriteTo.Console(
                            theme: AnsiConsoleTheme.Code,
                            outputTemplate: "[{Timestamp:yy-MM-dd HH:mm:ss.sssZ} {Level:u3}] {Message:lj} <s:{Environment}{Application}/{SourceContext}>{NewLine}{Exception}");
                        break;
                }
            });
