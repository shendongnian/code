 c#
public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IRequestLoggingService _requestLoggingService;
    public RequestLoggingMiddleware(RequestDelegate pNext, IRequestLoggingService pRequestLoggingService)
    {
        _next = pNext;
        _requestLoggingService = pRequestLoggingService;
    }
    public async Task InvokeAsync(HttpContext pHttpContext)
    {
        if (pHttpContext.Request.Path.StartsWithSegments(new PathString("/api")))
        {
            String requestBody;
            String responseBody = "";
            DateTime requestTime = DateTime.UtcNow;
            Stopwatch stopwatch;
            pHttpContext.Request.EnableBuffering();
            using (StreamReader reader = new StreamReader(pHttpContext.Request.Body,
                                                          encoding: Encoding.UTF8,
                                                          detectEncodingFromByteOrderMarks: false,
                                                          leaveOpen: true))
            {
                requestBody = await reader.ReadToEndAsync();
                pHttpContext.Request.Body.Position = 0;
            }
            Stream originalResponseStream = pHttpContext.Response.Body;
            using (MemoryStream responseStream = new MemoryStream())
            {
                pHttpContext.Response.Body = responseStream;
                stopwatch = Stopwatch.StartNew();
                await _next(pHttpContext);
                stopwatch.Stop();
                pHttpContext.Response.Body.Seek(0, SeekOrigin.Begin);
                responseBody = await new StreamReader(pHttpContext.Response.Body).ReadToEndAsync();
                pHttpContext.Response.Body.Seek(0, SeekOrigin.Begin);
                await responseStream.CopyToAsync(originalResponseStream);
            }
            await _requestLoggingService.LogRequest(new InsertRequestLog()
            {
                DateRequested = requestTime,
                ResponseDuration = stopwatch.ElapsedMilliseconds,
                StatusCode = pHttpContext.Response.StatusCode,
                Method = pHttpContext.Request.Method,
                Path = pHttpContext.Request.Path,
                QueryString = pHttpContext.Request.QueryString.ToString(),
                RequestBody = requestBody,
                ResponseBody = responseBody
            });
        }
        else
        {
            await _next(pHttpContext);
        }
    }
}
