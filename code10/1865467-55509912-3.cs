public void ConfigureServices(IServiceCollection services)
Actually you can setup and return `IServiceProvider`:
public class Startup 
{
  public IContainer Container { get; private set; }
  
  // ...
  public IServiceProvider ConfigureServices(IServiceCollection services)
  {
    // create new container builder
    var containerBuilder = new ContainerBuilder();
    // populate .NET Core services
    containerBuilder.Populate(services);
    // register your autofac modules
    containerBuilder.RegisterModule(new ApiModule());
    // build container
    Container = containerBuilder.Build();
    // return service provider
    return new AutofacServiceProvider(Container);
}
See more details in [official documentation](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.2#default-service-container-replacement)
