    using Owin;
    using Microsoft.Owin;
    using Microsoft.Owin.Security.Authorization.Infrastructure;
    using System.IdentityModel.Claims;
    
    [assembly: OwinStartup(typeof(Startup))]
    namespace Concep.Platform.WebApi.App_Start
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.UseAuthorization(options =>
                {
                    options.AddPolicy("AbleToCreateUser", policy => policy.RequireClaim(JwtClaimTypes.Role, "Manager"));
                });
            }
            
        }
    }
