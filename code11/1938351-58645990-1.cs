csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<AppDbContext>([...]);
    using (var serviceProvider = services.BuildServiceProvider())
    using (var serviceScope = serviceProvider.CreateScope())
    using (var context = scope.ServiceProvider.GetService<AppDbContext>())
    {
        context.Connections.RemoveRange(context.Connections);
        context.SaveChanges();
    }
    [...]
}
