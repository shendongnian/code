c-sharp
class Program
{
    static void Main(string[] args)
    {
        var errorLogConfiguration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("settings.json", optional: false, reloadOnChange: true)
            .Build();
        var log = new LoggerConfiguration()
            .ReadFrom
            .Configuration(errorLogConfiguration)
            .CreateLogger();
        log.Warning("Warning");
        log.Error("Error");
    }
}
