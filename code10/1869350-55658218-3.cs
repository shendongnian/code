csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
namespace YourNamespace
{
    public class YourCustomAttribute : TypeFilterAttribute
    { 
        public YourCustomAuthAttribute(
            : base(typeof(AuthFilter))
        {
            Arguments = new object[] {
               // arguments gets passed to AuthFilter contructor,
               
            };
        }
    }
    
    public class AuthFilter : IAsyncAuthorizationFilter
    {
        private static readonly HttpClient http = new HttpClient();
        public AuthFilter()
        {
        }
        //Change it to fit your logic
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var authorizationHeader = context.HttpContext.Request.Headers["Authtorization"];
            if (authorizationHeader == StringValues.Empty)
            {
                context.Result = new UnauthorizedResult();
            }
            else
            {
                var response = await http.GetAsync(
                    "your AuthServer address/login/?token=" + authorizationHeader.ToString(),
                    HttpCompletionOption.ResponseHeadersRead //because we want only status code
                );
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    context.Result = new ForbidResult();
                }
            }
        }
    }
}
Assuming you have a following endpoint in `LoginController` in AuthServer project
csharp
[HttpGet]
public IActionResult ValidateToken(string token)
{
   //your logic here
}
Attribute usage is the same as `[Authorize]`.
Check out this link too (I have used some code from it) https://www.red-gate.com/simple-talk/dotnet/net-development/jwt-authentication-microservices-net/. 
It's shown how to validate a Jwt token by hand.
You might also need to setup CORS in AuthServer project, to allow WebApi make a requests
`Startup.cs`:
csharp
public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
            });
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            app.UseCors("AllowAllHeaders");
        }
