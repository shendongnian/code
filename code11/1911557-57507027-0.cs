	services.Configure<MvcOptions>(options =>
	{
		options.EnableEndpointRouting = true;
	});
	services.Configure<MvcOptions>(options =>
	{
		options.EnableEndpointRouting = false;
		options.MaxValidationDepth = 3;
	});
	
