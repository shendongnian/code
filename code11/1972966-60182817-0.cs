public class MyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly JsonSerializerSettings _jsonSerializerSettings;
    public MyMiddleware(RequestDelegate next,IOptions<MvcNewtonsoftJsonOptions> jsonOptions)
    {
        // ... check null and throw
        this._next = next;
        this._jsonSerializerSettings = jsonOptions.Value.SerializerSettings;
    }
    public async Task Invoke(HttpContext context) 
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            //... removed for simplicity
            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse, _jsonSerializerSettings));
        }
    }
}
