lang-cs
[assembly: OwinStartup(typeof(MyWebApp.Api.StartUp))]
namespace MyWebApp.Api
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            // In OWIN you create your own HttpConfiguration rather than
            // re-using the GlobalConfiguration.
            HttpConfiguration httpconfig = new HttpConfiguration();
            httpconfig.Routes.MapHttpRoute(
                name: "ApiRouteWithAction",
                routeTemplate: "api/{controller}/{action}");
            httpconfig.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            // Autofac SignalR integration
            var builder = new ContainerBuilder();
            // Register Web API controller in executing assembly.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            // Register SignalR hubs.
            builder.RegisterHubs(Assembly.GetExecutingAssembly());
            // Registering Deletegates
            builder.Register(x => ServiceClientProvider.GetServiceClient())
                .As<IMyService>()
                .InstancePerRequest();
            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            httpconfig.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            app.UseWebApi(httpconfig);
            // Register the Autofac middleware FIRST, then the custom middleware if any.
            app.UseAutofacMiddleware(container);
        }
    }
}
The controller & abstract class it inherited from, were tweaked, removing the parameterless constructors.
lang-cs
public abstract class BaseApiController
{
	public IMyService serviceClient { get; set; }
	public BaseApiController(IMyService serviceClient)
	{
		this.serviceClient = serviceClient;
	}
}
Every controller inherits from the above class, while some employs a default Get method, most have multiple routes. Not a single controller is specifying a constructor:
lang-cs
public class MyController : BaseApiController
{
	public MyController(IMyService serviceClient) : base(serviceClient) {}
	[HttpGet]
	[Route("api/foo/bar")]
	[ActionName("FooBar")]
	public string FooBar()
	{
		using (serviceClient)
		{
			return serviceClient.GetFooBar() as string;
		}
	}
}
Thanks for the interest, hopefully my rookie mistake will help another rookie.
