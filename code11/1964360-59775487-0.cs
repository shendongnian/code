csharp
public static IHost MigrateDbContext<TContext>(this IHost host) where TContext : DbContext
{
    // Create a scope to get scoped services.
    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<TContext>>();
        // get the service provider and db context.
        var context = services.GetService<TContext>();
        // do something you can customize.
        // For example, I will migrate the database.
        context.Database.Migrate();
    }
    return host;
}
It creates an extended method for IHost which allows you to upgrade your database automatically after the application starts. It uses your application's default service provider to create a scope and get your `DBContext`. And try to migrate the database to the latest status.
If your database is empty or does not exists at all, the script can also create your database automatically.
Finally, use the extend method in your startup process. Like this:
csharp
public static void Main(string[] args)
{
    CreateHostBuilder(args)
        .Build()
        .MigrateDbContext<WikiDbContext>() // <-- call it here like this.
        .Run();
}
public static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
}
Try to start your application, and monitor if it can successfully execute the update process.
When you are executing other `ef` commands like `dotnet ef migrations add Test` and the script will not be executed. Your database is still the same.
Hope this helps.
