   app.UseExceptionHandler(errorApp =>
   {
        errorApp.Run(async context =>
        {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
 
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFeature != null)
                    {  
                        await context.Response.WriteAsync(new ExceptionInfo()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error."
                        }.ToString());
                    }
        });
    });
And `ExceptionInfo` class:
public class ExceptionInfo
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
 
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
**Update 1:**
The order of middlewares is very important, you MUST put it before any other middlewares such as `mvc`:
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
 
    app.UseExceptionHandler(... like code above);
 
    app.UseHttpsRedirection();
    app.UseMvc();
**Update 2:**
In case of logging your exceptions, you can inject your logger by adding its type to the `Configure` method in `Startup` class:
public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger logger)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
 
    app.UseExceptionHandler(... like code above);
 
    app.UseHttpsRedirection();
    app.UseMvc();
}
**Update 3:**
Use a custom middleware as a global exception handler:
public class CustomErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILoggerManager _logger;
 
    public ExceptionMiddleware(RequestDelegate next, Ilogger logger)
    {
        _logger = logger;
        _next = next;
    }
 
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong: {ex}");
            await HandleExceptionAsync(httpContext, ex);
        }
    }
 
    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
 
        return context.Response.WriteAsync(new ExceptionInfo()
        {
            StatusCode = context.Response.StatusCode,
            Message = "Internal Server Error"
        }.ToString());
    }
}
Then use it in `Configure` method:
app.UseMiddleware<CustomErrorHandlerMiddleware>();
**TL;DR:**
[Handle errors in ASP.NET Core][1]
[ASP.NET Core Middleware][2]
  [1]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/error-handling?view=aspnetcore-2.2
  [2]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-2.2
