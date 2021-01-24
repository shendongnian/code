csharp
public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateWebHostBuilder(args).Build();
        host.Run();
        var config = host.Services.GetService<IConfiguration>();
        var configSection = config.GetSection("ConfigurationModel");
        var configModel = configSection.Get<ConfigurationModel>();
        SetRfid(configModel);
    }
    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
    public static void SetRfid(ConfigurationModel configModel)
    {
        var rfidClass = new RfidClass(configModel); <-- ADDED
    }
}
