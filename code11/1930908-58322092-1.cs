    private static Configuration GetJSONConnection()
    {
        var builder = new ConfigurationBuilder();
        builder.AddJsonFile("appsettings.json", optional: false);
        var configuration = builder.Build();
        return configuration;
    }
    public static void CreateDB()
    {
        var connectionString = GetJSONConnection().GetConnectionString("SQLConnection");
    }
