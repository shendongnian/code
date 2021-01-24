cs
public void ConfigureServices(IServiceCollection services)
{
    services.AddRazorPages();
    services.AddDbContext<EFCoreExampleContext>(o => o.UseMySql("server=etc..."));
}
In my DB project I had this in the DbContext-derived class:
cs
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseMySql("server=etc...");
}
Even though I was using `Update-Database -Project MyDbProj`, it was using the connection string in the other project. If I removed the `AddDbContext` line from Startup.cs, I just got a different error. Removing the `OnConfiguring` method was the only way to get it to work.
