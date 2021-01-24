    public class AutofacRegistration
    {
        public static void BuildContainer()
        {
            var builder = new ContainerBuilder();
            // Register your MVC controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            // Now grab your connection string and wire up your db context
            var conn = ConfigurationManager.ConnectionStrings["BloggingContext"];
            builder.Register(c => new BloggingContext(conn));
            // You can register any other dependencies here
            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
