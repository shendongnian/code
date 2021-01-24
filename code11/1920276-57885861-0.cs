 c#
public class RouteMiddleWare
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RouteMiddleWare> _logger;
    public RouteMiddleWare(RequestDelegate next, ILogger<RouteMiddleWare> logger)
    {
        _next = next;
        _logger = logger;
    }
    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Method == "POST")
        {
            var requestBody = new MemoryStream();
            context.Request.Body.CopyTo(requestBody);
            requestBody.Seek(0, SeekOrigin.Begin);
            var streamReader = new StreamReader(requestBody);
            
            try
            {
                var body = streamReader.ReadToEnd();
                var request = JsonConvert.DeserializeObject<Request>(body);
                context.Request.Path = request.Method;
                context.Request.Body =
                    new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(request.Data)));
                using (requestBody) _logger.LogInformation("Request body stream has been replaced");
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Failed to apply route from body: {ex.Message}");
                context.Request.Body = requestBody;
            }
            context.Request.Body.Seek(0, SeekOrigin.Begin);
        }
        await _next.Invoke(context);
    }
    class Request
    {
        public string UniqueRequestId { get; set; }
        public string Method { get; set; }
        public dynamic Data { get; set; }
    }
}
*On the other hand, it would be better to change the client code to use proper paths.* 
  [1]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-2.2
