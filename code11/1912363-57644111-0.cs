 public class  SoapAuthorizationMiddleware
    {
        private readonly RequestDelegate next;
        public  SoapAuthorizationMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            
                string authHeader = context.Request.Headers["Authorization"];
                if (authHeader != null && authHeader.StartsWith("basic", StringComparison.OrdinalIgnoreCase))
                {
                    string token = authHeader.Substring("Basic ".Length).Trim();
                    var credentialstring = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                    var credentials = credentialstring.Split(':');
                    string username = credentials[0];
                    string password = credentials[1];
                    SoapImplementation.Authenticate(username, password);
                }
                else
                {
                    SoapImplementation.Authenticate(string.Empty, string.Empty);
                    context.Response.StatusCode = 401;
                    context.Response.Headers["WWW-Authenticate"] = "Basic";
                }
            
            await next(context);
        }
    }
then use this middle ware on startup.cs 
 app.UseWhen(x => (x.Request.Path.StartsWithSegments("/yourservicename.asmx", StringComparison.OrdinalIgnoreCase)),
            builder =>
            {
                builder.UseMiddleware<SoapAuthorizationMiddleware>();
            });
