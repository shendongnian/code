	app.UseStatusCodePages(context =>
	{
		context.HttpContext.Response.ContentType = "text/plain";
		return context.HttpContext.Response.WriteAsync(
			"Status code page, status code: " + 
			context.HttpContext.Response.StatusCode);
	});
