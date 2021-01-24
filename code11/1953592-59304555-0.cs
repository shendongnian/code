GET https://graph.microsoft.com/v1.0/users/{id | userPrincipalName}
- You can use an middleware to get the currently logged on user informations, claims and add it to your Identity User.
 public class Middleware
    {
        private readonly RequestDelegate _next;
        public Middleware(RequestDelegate next)
        {
            _next = next;
        }
       public async Task Invoke(HttpContext httpContext)
       {
            if (httpContext.Request.Headers.ContainsKey("X-MS-CLIENT-PRINCIPAL-ID"))
            {
                 // Read headers from Azure and get jwt claims
                 var idHeader = httpContext.Request.Headers["X-MS-CLIENT-PRINCIPAL-ID"][0];
                 var idTokenHeader = httpContext.Request.Headers["X-MS-TOKEN-AAD-ID-TOKEN"][0];
                 var handler = new JwtSecurityTokenHandler();
                 var jwtToken = handler.ReadToken(idTokenHeader) as JwtSecurityToken;
                 var jwtClaims = jwtToken.Claims.ToList();
                 jwtClaims.Add(new Claim("http://schemas.microsoft.com/identity/claims/objectidentifier", idHeader));
                 // Set user in current context as claims principal
                 var identity = new GenericIdentity(idHeader);
                 identity.AddClaims(jwtClaims);
                 // Set current thread user to identity
                 httpContext.User = new GenericPrincipal(identity, null);
            }
            await _next.Invoke(httpContext);
       }
// Extension method used to add the middleware to the HTTP request pipeline.
    public static class Middleware
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
//and is startup use it like this: 
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
   app.UseMiddleware();
}
