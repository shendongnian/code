    public class WideOpenCorsMiddleware
    {
        private readonly RequestDelegate _next;
    
        public WideOpenCorsMiddleware(RequestDelegate next)
        {
            _next = next;
        }
    
        public async Task Invoke(HttpContext context)
        {
            var response = context.Response;
    
            // check if it's an ajax request
            if (context.Request.Headers != null && context.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                response.Headers.Add("Access-Control-Allow-Origin",
                    new[] { (string)context.Request.Headers["Origin"] });
                response.Headers.Add("Access-Control-Allow-Headers",
                    new[] { "Origin, X-Requested-With, Content-Type, Accept" });
                response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET, POST, PUT, DELETE, OPTIONS" });
                response.Headers.Add("Access-Control-Allow-Credentials", new[] { "true" });
                response.StatusCode = 200;
            }
    
            // if not a pre-flight request
            if (context.Request.Method != "OPTIONS")
            {
                await _next(context);
            }
        }
    }
