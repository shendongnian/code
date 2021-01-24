	services.Configure<MvcOptions>(options =>
	{
		options.EnableEndpointRouting = true;
        // the last options win
		options.EnableEndpointRouting = false;
		options.MaxValidationDepth = 3;
	});
