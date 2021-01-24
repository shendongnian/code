    services.AddMvc.SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
    .ConfigureApiBehaviorOptions(options =>
    {
    	options.InvalidModelStateResponseFactory = context =>
    	{
    		var problems = new CustomBadRequest(context);
    		return new BadRequestObjectResult(problems);
    	};
    });
