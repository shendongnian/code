asp
public class MyDependency 
{
    // You can use dependency injection in a chained fashion, 
    // DBContext is injected in our dependency
    private readonly DBContext _dbContext;
    public MyDependency(DBContext dbContext)
    {
        _dbContext = dbContext;
    }
    // Define a method that access DB using dbContext
    public bool CheckInDb()
    {
        return dbContext.SomeCheck();
    }
}
Register it to your services in your `Startup` (Your dependency should be registered after DBContext has been registered)
asp
public void ConfigureServices(IServiceCollection services)
{
    // Some code here
    services.AddDbContext<DBContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    services.AddScoped<MyDependency>();
}
Then in your layout:
asp
@inject MyDependency MyDependency
@if(MyDependency.CheckInDb())
{
    // Do something
} 
else
{
    // Do something else
}
