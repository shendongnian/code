    using Owin;
    using your_namespace.Web.Http.Validation;
    
    [assembly: OwinStartup(typeof(your_namespace.Startup))]
    
    namespace your_namespace
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                Configuration(app, new HttpConfiguration());
            }
    
            public void Configuration(IAppBuilder app, HttpConfiguration config)
            {
                config.Services.Replace(typeof(IBodyModelValidator), new IgnoreRequiredOrDefaultBodyModelValidator());
            }
    
    		...
