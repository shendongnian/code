    public class Startup
    {
      // Omitting extra stuff so you can see the important part...
      public void ConfigureServices(IServiceCollection services)
      {
        // Add controllers as services so they'll be resolved.
        services.AddMvc().AddControllersAsServices();
      }
      public void ConfigureContainer(ContainerBuilder builder)
      {
        // If you want to set up a controller for, say, property injection
        // you can override the controller registration after populating services.
        builder.Register(c => new KeysController(c.ResolveNamed<IService>("ServiceOne")));
        builder.Register(c => new ValuesController(c.ResolveNamed<IService>("ServiceTwo")));
      }
    }
