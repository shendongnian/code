    public class DenyAnonymousMiddleware
    {
        private readonly RequestDelegate _next;
    
        public DenyAnonymousMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
    
        public async Task InvokeAsync(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            if (string.IsNullOrEmpty(context.User?.Identity?.Name) && !endpoint.Metadata.OfType<AllowNullAttribute>().Any())
            {
                context.Response.StatusCode = 401;
                var values = new StringValues(new string[] { "Negotiate", "NTLM" });
                context.Response.Headers.Add(HeaderNames.WWWAuthenticate, values);
                await context.Response.WriteAsync("Unauthorized Windows User");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
