    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        public ErrorHandlingMiddleware(RequestDelegate next, IOptions<MvcJsonOptions> mvcJsonOptions)
        {
            _next = next;
            _jsonSerializerSettings = mvcJsonOptions.Value.SerializerSettings;
        }
        
        ...
        private Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger logger)
        {
            ...
            var result = JsonConvert.SerializeObject(errorResponse, _jsonSerializerSettings);
            ...
        }
    }
