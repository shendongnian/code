    services.AddMvc()
    	.ConfigureApiBehaviorOptions(options => {
    		options.InvalidModelStateResponseFactory = actionContext =>
    		{
    			var modelState = actionContext.ModelState.Values;
    			return new BadRequestObjectResult(new ErrorResult(modelState));
    		};
    	});
    });
