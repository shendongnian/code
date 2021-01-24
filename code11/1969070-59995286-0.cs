C#
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            ...
            if (user.Identity.IsAuthenticated)
            {
                var connectionString = context.HttpContext.RequestServices
                    .GetService(typeof(IConfiguration))
                    .GetConnectionString("myConnectionString");
               // GetConnectionString is an extension method, so add
               // using Microsoft.Extensions.Configuration
               
               ...
            }
        }
Using this technique, you could also simply use your `DbContext` as well.
