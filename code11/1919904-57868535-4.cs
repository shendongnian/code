c#
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace YourNamespace.Services
{
    public static class MyAppContext
    {
        private static readonly IHttpContextAccessor _httpContextAccessor;
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            // ...
        }
        public static int GetClientID()
        {
            int result = 0;
            var claim = CurrentHttpContext.User.Claims.FirstOrDefault(c => c.Type == "ClientID");
            if (claim != null)
            {
                result = Convert.ToInt32(claim.Value);
            }
            return result;
        }
        // You can even expose the current HTTP context
        public static HttpContext CurrentHttpContext { get { return _httpContextAccessor.HttpContext; } }
    }
}
In **Startup.cs**, configure the service:
c#
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // if using .NET Core 2.1 or above use:
        // services.AddHttpContextAccessor();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        // ...
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        //...
        var ctx = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
        YourNamespace.Services.MyAppContext.Configure(ctx);
        // ...
    }
}
Thanks to constructive critics/suggestions, I think this is a better solution.
