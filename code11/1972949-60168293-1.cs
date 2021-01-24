    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
    	app.UseExceptionHandler(appBuilder =>
    	{
    		appBuilder.Run(async context =>
    		{
    			var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
    			if (exceptionHandlerFeature != null)
    			{
    				var exception = exceptionHandlerFeature.Error;
    				if(exception == YourNotFoundException)
    				{
    					context.Response.StatusCode = 404;
    					await context.Response.WriteAsync("Could not find resource");
    				}
    				//you can also have global logging here eg:
    				//var logger = loggerFactory.CreateLogger("Global exception logger");
    				//logger.LogError(500, exception, exception.Message);
    			}
    			else
    			{
    				context.Response.StatusCode = 500;
    				await context.Response.WriteAsync("an unexpected fault happened. Try again later.");
    			}
    			
    		});
    	});
    	...
    }
