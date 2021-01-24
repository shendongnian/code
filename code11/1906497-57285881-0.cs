     services.AddMvc()
             .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = actionContext =>
                    {
                        return new BadRequestObjectResult(FormatOutput(actionContext.ModelState));
                    };
                });
