private static IConfiguration config;
[BeforeScenario]
public void CreateConfig()
{
    if (config == null)
    {
        config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
    }
    
     container.RegisterInstanceAs<IConfiguration>(config);
}
