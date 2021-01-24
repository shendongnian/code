c#
public static class LoggerEnrichmentConfigurationExtensions
{
    public static LoggerConfiguration WithExceptionDetailsWithoutReflection(
        this LoggerEnrichmentConfiguration loggerEnrichmentConfiguration)
    {
        if (loggerEnrichmentConfiguration is null)
        {
            throw new ArgumentNullException(nameof(loggerEnrichmentConfiguration));
        }
        var options = new DestructuringOptionsBuilder()
            .WithDefaultDestructurers()
            .WithoutReflectionBasedDestructurer() //new in 5.4.0!
            .WithIgnoreStackTraceAndTargetSiteExceptionFilter();
        var logEventEnricher = new ExceptionEnricher(options);
        return loggerEnrichmentConfiguration.With(logEventEnricher);
    }
}
### Config
c#
Log.Logger = new LoggerConfiguration()
				.ReadFrom.Configuration(configuration)
				.Enrich.WithExceptionDetailsWithoutReflection()
				.CreateLogger();
