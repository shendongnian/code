    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
    {
    	app.Use(async (context, next) =>
    	{
    		logger.LogInformation($"Header: {JsonConvert.SerializeObject(context.Request.Headers, Formatting.Indented)}");
    
    		context.Request.EnableBuffering();
    		var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
    		logger.LogInformation($"Body: {body}");
    		context.Request.Body.Position = 0;
    
    		logger.LogInformation($"Host: {context.Request.Host.Host}");
    		logger.LogInformation($"Client IP: {context.Connection.RemoteIpAddress}");
    		await next.Invoke();
    	});
    }
