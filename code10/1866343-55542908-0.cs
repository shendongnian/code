csharp
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    //...
    app.UseMyExceptionHandler();
    // ...
    app.UseMvc();
}
The middleware could look like this:
csharp
public class ExceptionHandlerMiddleware
{
    readonly RequestDelegate _next;
    readonly ILogger logger;
    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        this.logger = logger;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }
    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        // Log the exceptions
        string result = ... cretate the response if you need it
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 500;
        return context.Response.WriteAsync(result);
    }
}
And I used the extension method to add it to the app builder:
csharp
public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseMyExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}
Now you can remove the `try/catch` from all your controller actions, because all the unhandled exceptions will be caught by the middleware.
There are also some [built-in ways][2] of doing this that might help you.
**CHALLENGE 2: null checks for NotFound**
You can create some base controller that all your controllers will inherit from, and handle the `null` check in it:
csharp
public class BaseController : ControllerBase
{
    protected IActionResult CreateResponse(object result)
    {
        if (results == null)
            return NotFound();
        return Ok(results);
    }
}
and then you make all your controllers inherit from it:
csharp
[ApiController]
public class YourController : BaseController
// ...
And now your action method could look like this:
csharp
[HttpGet()]
[Route("Contracts/{id}")]
public async Task<IActionResult> Get(int id)
{
    var results = await _service.GetContractByIdAsync(id);
    return CreateResponse(results);
}
  [1]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-2.2
  [2]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/error-handling?view=aspnetcore-2.2
