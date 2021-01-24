    public static IConfiguration InitConfiguration()
    {
        var settingsFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "appsettings.*.json"));
        if (settingsFiles.Length != 1) throw new Exception($"Expect to have exactly one configuration-specfic settings file, but found {string.Join(", ", settingsFiles)}.");
        var settingsFile = settingsFiles.First();
    
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile(settingsFile)
            .AddEnvironmentVariables();
        var configuration = builder.Build();
    
        // Testing to see if the above worked
        string url = configuration["url"];
        string driverdirectory = configuration["driverdirectory"];
    
        return configuration;
    }
