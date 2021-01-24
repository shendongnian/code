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
Update 1:
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
TL;DR:
[Handle errors in ASP.NET Core][1]
[ASP.NET Core Middleware][2]
  [1]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/error-handling?view=aspnetcore-2.2
  [2]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-2.2
