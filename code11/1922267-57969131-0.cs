c#
public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // New code
            config.EnableCors();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
Next, add the [EnableCors] attribute to the TestController class:
c#
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
namespace WebService.Controllers
{
    [EnableCors(origins: "http://host-name.com", headers: "*", methods: "*")]
    public class TestController : ApiController
    {
        // Controller methods not shown...
    }
}
