csharp
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
	app.UseCors(pol => pol.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
	app.UseAuthentication();
	if (env.IsDevelopment())
		app.UseDeveloperExceptionPage();
	app.UseStatusCodePages(async context =>
	{
		if (context.HttpContext.Request.Path.StartsWithSegments("/api"))
		{
			if (!context.HttpContext.Response.ContentLength.HasValue || context.HttpContext.Response.ContentLength == 0)
			{
                // You can change ContentType as json serialize
				context.HttpContext.Response.ContentType = "text/plain";
				await context.HttpContext.Response.WriteAsync($"Status Code: {context.HttpContext.Response.StatusCode}");
			}
		}
		else
		{
            // You can ignore redirect
			context.HttpContext.Response.Redirect($"/error?code={context.HttpContext.Response.StatusCode}");
		}
	});
	app.UseMvc();
}
## Option 2
csharp
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
	...
	app.UseExceptionHandler("/api/errors/500");
	app.UseStatusCodePagesWithReExecute("/api/errors/{0}");
  
	...
}
Then, create ErrorController like:
csharp
[ApiController]
[Route("api/errors")]
public class ErrorController : Controller
{
	[HttpGet("{code}")]
	public async Task<IActionResult> Get(int code)
	{
		return await Task.Run(() =>
		{
			return StatusCode(code, new ProblemDetails()
			{
				Detail = "See the errors property for details.",
				Instance = HttpContext.Request.Path,
				Status = code,
				Title = ((HttpStatusCode)code).ToString(),
				Type = "https://my.api.com/response"
			});
		});
	}
}
I hope this helps.
