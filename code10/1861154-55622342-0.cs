    public class WindowsUserMiddleware
    {
        private readonly RequestDelegate _next;
        public WindowsUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            var claims = new List<Claim> { /* add claims */ };
            var userIdentity = new ClaimsIdentity(claims, "NonEmptyAuthType");
            httpContext.User = new ClaimsPrincipal(userIdentity);
            await _next(httpContext);
        }
    }
    public static class WindowsUserMiddlewareExtensions
    {
        public static IApplicationBuilder UseWindowsUser(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<WindowsUserMiddleware>();
        }
    }
