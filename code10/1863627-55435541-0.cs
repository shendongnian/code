ReadOnly IServiceProvider _ServiceProvider;
MySingulation(IServiceProvider serviceProvider)
{
    _ServiceProvider = serviceProvider;
}
Once we have a handle to IServiceProvider through injection, we can use MVC Core API to create instances of our context
using(var serviceScope = _ServiceProvider.CreateScope())
{
    // Don't get confused -- Call GetService from the serviceScope and 
    // not directly from the member variable _ServiceProvider. 
    var context = serviceScope.ServiceProvider.GetService<YourAppDbContext>();
    
    // ...
    // Make use of the dbcontext
    // ...
    
}
Now, it just important to remember we make use of MVC Core Pooling in the Startup.cs to begin with. 
public void ConfigureServices(IServiceCollection services)
{
    //...
    services.AddDbContextPool<YourAppDbContext>(options => {
        options.UseSqlServer(settings.Connection);
    });
    // Oh, it's important the singultion was created within Core's LifeCycle/API
    services.AddSingleton<MySingulation>();
    //...
}   
