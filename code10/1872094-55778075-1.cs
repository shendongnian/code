c#
    public static class Extensions
    {
        public static IWebHostBuilder UseLogging(this IWebHostBuilder webHostBuilder) =>
            webHostBuilder.UseSerilog((context, loggerConfiguration) =>
            {
                var logLevel = context.Configuration.GetValue<string>("Serilog:MinimumLevel");
                if (!Enum.TryParse<LogEventLevel>(logLevel, true, out var level))
                {
                    level = LogEventLevel.Information;
                }
                loggerConfiguration.Enrich
                    .FromLogContext()
                    .MinimumLevel.Is(level);
                loggerConfiguration
                    .ReadFrom.Configuration(context.Configuration);
                // Get the field that holds the sinks.
                var sinks = loggerConfiguration.GetType()
                    .GetField("_logEventSinks", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(loggerConfiguration) as List<ILogEventSink>;
                // Get the sink type for reusage.
                var sinkType = typeof(AnsiConsoleTheme).Assembly.GetType("Serilog.Sinks.SystemConsole.ConsoleSink");
                // Find the first sink of the right type.
                var sink = sinks?.FirstOrDefault(s => sinkType == s.GetType());
                
                // Check if a sink was found.
                if (sink == null)
                {
                    // No sink found add a new one.
                    loggerConfiguration
                        .WriteTo.Console(
                            theme: AnsiConsoleTheme.Code,
                            outputTemplate:
                            "[{Timestamp:yy-MM-dd HH:mm:ss} {Level:u3}] {Message:lj} <s:{SourceContext}>{NewLine}{Exception}");
                }
                else
                {
                    // Otherwise change the theme.
                    sinkType.GetField("_theme", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(sink, AnsiConsoleTheme.Code);
                }
            });
    }
