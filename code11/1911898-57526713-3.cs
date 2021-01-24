    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<MyAutofacModule>();
            // Register anything else needed
            var container = builder.Build();
            // MVC resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            // API Resolver
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
