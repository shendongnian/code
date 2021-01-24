    public class MyMiddleware
    {
        private readonly RequestDelegate _next;
        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            string body;
            using (var streamReader = new System.IO.StreamReader(httpContext.Request.Body, System.Text.Encoding.UTF8))
            {
                body = await streamReader.ReadToEndAsync();
            }
            await httpContext.Response.WriteAsync(body);
        }
    }
