    //For OWIN you could do something like the following.
    public class Startup
    {
      public void Configuration(IAppBuilder app)
      {
        var container = YourObject.SetupContainer();
    
        // Register the Autofac middleware FIRST. This also adds
        // Autofac-injected middleware registered with the container.
        app.UseAutofacMiddleware(container);
    
        // ...then register your other middleware not registered
        // with Autofac.
      }
    }
    //In your Global.asax.cs 
    
        protected void Application_Start() 
        {
         
           var container = YourObject.SetupContainer();
           DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
    
        }
