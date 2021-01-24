// Autofac
builder.Register(c => new HttpContextWrapper(HttpContext.Current))
            .As<HttpContextBase>()
            .InstancePerRequest();
// Again Autofac 
builder.RegisterModule(new AutofacWebTypesModule());
// Castle Windsor
container.Register(Component.For<HttpContextBase()
                  .LifeStyle.PerWebRequest
                  .UsingFactoryMethod(() => new HttpContextWrapper(HttpContext.Current)));
With controllers using contructor injection:
public class HomeController : Controller
{
    private readonly HttpContextBase _httpContext;
    public HomeController(HttpContextBase httpContext)
    {
        _httpContext = httpContext;
    }
}
So you inject `HttpContextBase` in order to access the context
public class EntitiesContext : DbContext
{
    
	private readonly HttpContextBase _httpContext;
    public EntitiesContext(HttpContextBase httpContext)
    {
        _httpContext = httpContext;
    }
	
}
