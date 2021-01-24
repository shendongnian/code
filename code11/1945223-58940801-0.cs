public static IWebHost MigrateDatabase<T>(this IWebHost webHost) where T : DbContext
{
    using(var scope = webHost.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var db = services.GetRequiredService<T>();
            db.Database.Migrate();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred while migrating the database.");
        }
    }
    return webHost;
}
It can be used in the main entry point as follows:
public static void Main(string[] args)
{
    CreateWebHostBuilder(args)
        .Build()
        .MigrateDatabase<DatabaseContext>()
        .Run();
}
While it does not run the migrations as part of the deployment process, but as part of the startup process, I felt it was much easier and required less moving parts in order to get started. This also allowed shipping a much smaller image which simply contains the runtime and not the SDK along with all the tooling.
