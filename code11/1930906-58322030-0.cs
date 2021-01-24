 csharp
private static IConfiguration _configuration;
private static void GetJSONConnection()
{
     var builder = new ConfigurationBuilder();
     builder.AddJsonFile("appsettings.json", optional: false);
     _configuration = builder.Build();
}
public static void CreateDB()
{
     var connectionString = _configuration.GetConnectionString("SQLConnection");
}
