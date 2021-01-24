c#
public void ConfigureServices(IServiceCollection services)
{
    services.Configure<ConnectionString>(Configuration.GetSection(nameof(ConnectionStrings))AddOptionsSnapshot<ConnectionStrings>();
    services.AddControllersWithViews();
}
Then on the controller:
c#
internal ConnectionStrings ConnectionStrings
{
    get
    {
        return this.HttpContext.RequestServices.GetRequiredService<ConnectionStrings>();
    }
}
