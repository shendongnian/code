csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<AppDbContext>([...]);
    using (var scope = services.BuildServiceProvider().CreateScope())
    {
        var context = scope.ServiceProvider.GetService<AppDbContext>();
        context.Connections.RemoveRange(context.Connections);
        context.SaveChanges();
    }
    [...]
}
