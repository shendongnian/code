c#
public interface IStagingService 
{
    Task Save(int logNumber);
}
public class MyController : ControllerBase
{
    private readonly IStagingService _service;
    private readonly IHttpContextAccessor _accessor;
    public MyController(IStagingService service, IHttpContextAccessor accessor)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _accessor = accessor  ?? throw new ArgumentNullException(nameof(accessor));;
    }
    //....
}
public class MyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IStagingService _service;
    public RequestCultureMiddleware(RequestDelegate next, IStagingService service)
    {
        _next = next;
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }
    public async Task InvokeAsync(HttpContext context)
    {
    // ...
}
In the beginning, your service's will likely start out small and simple. In the event the app grows, the complexity of this layer will likely increase, spawning the need for some [facade](https://en.wikipedia.org/wiki/Facade_pattern) services (i.e. services composed of services) and maybe some providers for thing like data access.
