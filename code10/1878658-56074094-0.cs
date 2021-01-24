[assembly: OwinStartupAttribute(typeof(Go.Startup))]
namespace MyName
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = CompositionRoot.Compose();
            var controllerFactory = new InjectableControllerFactory(container);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            MvcSiteMapProviderConfig.Register(container);
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
            //GlobalHost.HubPipeline.RequireAuthentication(); <---------
            app.MapSignalR(new HubConfiguration
            {
                EnableJSONP = true,
                EnableJavaScriptProxies = true,
                EnableDetailedErrors = true
            });
        }
    }
}
