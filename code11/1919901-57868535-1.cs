c#
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // ...
        services.TryAddTransient<IHttpContextAccessor, HttpContextAccessor>();
        // ...
    }
}
In your controller (if you're using MVC) then get your claim like so:
c#
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace YourNamespace.Controllers
{
    public class MyController : Controller
    {
        private readonly IHttpContextAccessor _httpContext;
        public MyController(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
            var claim = _httpContext.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "ClientID");
        // ...
        }
    }
}
If you want to create an extension method for this, then do it like:
c#
using System.Linq;
using Microsoft.AspNetCore.Http;
namespace YourNamespace.Extensions
{
    public static class OwinContextExtensions
    {
    
        public static int GetClientID(this IHttpContextAccessor currentContext)
        {
            int result = 0;
            var claim = currentContext.Authentication.User.Claims.FirstOrDefault(c => c.Type == "ClientID");
    
            if (claim != null)
            {
                result = Convert.ToInt32(claim.Value);
            }
            return result;
        }
    }
}
Your controller code should look like this:
c#
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourNamespace.Extensions;
namespace YourNamespace.Controllers
{
    public class MyController : Controller
    {
        private readonly IHttpContextAccessor _httpContext;
        public MyController(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
            var claim = httpContext.GetClientID();
        }
    }
}
