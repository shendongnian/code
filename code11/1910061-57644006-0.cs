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
I hope this helps.
