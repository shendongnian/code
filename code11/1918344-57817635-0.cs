public class Program
{
    public static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
             // custom config file
            .AddJsonFile("customconfig.json", optional: false, reloadOnChange: false)
            .Build();
        BuildWebHost(args, configuration).Run();
    }
    public static IWebHost BuildWebHost(string[] args, IConfiguration config) =>
        WebHost.CreateDefaultBuilder(args)
            .UseConfiguration(config)
            .UseStartup<Startup>()
            .Build();
}
