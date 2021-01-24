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
