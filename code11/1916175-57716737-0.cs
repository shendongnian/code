c#
public class AutofacConfig
    {
        public static void Register(IAppBuilder app, HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.Register(c => HttpContext.Current.Request.GetOwinContext()).As<IOwinContext>().InstancePerRequest();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();
            //this is in another module in different library which I am calling from here using builder.RegisterModule
            builder.RegisterType<UserManager>().As<IManager<User>>().InstancePerRequest();
            //Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            // Register the Autofac middleware FIRST, then the Autofac Web API middleware,
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
        }
    }
