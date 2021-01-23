    private static string GetConnectionString()
    {
        var config = WebConfigurationManager.OpenWebConfiguration("/myProject");
        var connections = config.ConnectionStrings;
        var settings = connections.ConnectionStrings["myConnectionStringname"];
        string connectionString = settings.ConnectionString;
        return connectionString;
    }
