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
                var sinks = loggerConfiguration.GetType()
                    .GetField("_logEventSinks", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(loggerConfiguration) as List<ILogEventSink>;
                var sink = sinks.FirstOrDefault(s => typeof(AnsiConsoleTheme).Assembly.GetType("Serilog.Sinks.SystemConsole.ConsoleSink") == s.GetType());
                if (sink == null)
                {
                    loggerConfiguration
                        .WriteTo.Console(
                            theme: AnsiConsoleTheme.Code,
                            outputTemplate:
                            "[{Timestamp:yy-MM-dd HH:mm:ss} {Level:u3}] {Message:lj} <s:{SourceContext}>{NewLine}{Exception}");
                }
            });
    }
