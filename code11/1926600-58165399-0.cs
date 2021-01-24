    public class AddHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        public AddHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var data = context.Session.GetString("StickyCookie");
            context.Request.Headers.Add("StickyCookie", data);
            context.Response.OnStarting(state =>
            {
                var httpContext = (HttpContext)state;
                var cookies = httpContext.Response.Headers["Set-Cookie"].ToString().Split(";");
                if (cookies.Length > 0)
                {
                    foreach (var item in cookies)
                    {
                        if (item.Split("=")[0] == "StickyCookie")
                        {
                            var cookie = item.Split("=")[1];
                            httpContext.Session.SetString("StickyCookie", cookie);
                        }
                    }
                }
                return Task.FromResult(0);
            }, context);
            await _next(context);
        }
    }
    public static class AddHeaderMiddlewareExtensions
    {
        public static IApplicationBuilder UseAddHeader(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AddHeaderMiddleware>();
        }
    }
