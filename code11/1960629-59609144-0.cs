public class SampleMiddleware
{
	private readonly RequestDelegate _next;
	public SampleMiddleware(RequestDelegate next)
	{
		_next = next;
	}
	public async Task InvokeAsync(HttpContext httpContext)
	{
        //you can have access for 
		httpContext.Request.Query
		httpContext.Request.Headers
		httpContext.Request.Body
    }
}
and you can make this `SampleMiddleware.InvokeAsync` to be executed for every method in the controller with the `Microsoft.AspNetCore.Builder.UseMiddlewareExtensions`
public class Startup
{
public void Configure(IApplicationBuilder app)
{
app.UseMiddleware<SampleMiddleware>();
}
}
