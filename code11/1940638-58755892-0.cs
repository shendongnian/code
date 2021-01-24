// Startup.cs
public class Startup
{
    // ...
    public void ConfigureServices(IServiceCollection services, IHostingEnvironment env)
    {
        // [2]
        var connectionString = "customer.json"; // or get from a config file
        services.AddSingleton<Repository>(new Repository(connectionString, env));
    }
    // ...
}
public class Customers
{
    private Repository _repository;
    public Customers(Repository repository)
    {
        // [1]
        _repository = repository;
    }
    public string Get()
    {
        // you can use _repository here without passing stuff in
    }
}
public class Repository
{
    private IHostingEnvironment _env;
    public Repository(string connectionString, IHostingEnvironment env)
    {
        _env = env;
    }
}
.NET Core Dependency Injection - https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.2
