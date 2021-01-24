      services.AddMvc()
                    .ConfigureApiBehaviorOptions(options =>
                    {
                        options.InvalidModelStateResponseFactory = actionContext =>
                        {
                            var modelState = actionContext.ModelState;
                            return new BadRequestObjectResult(FormatOutput(modelState));
                        };
                    })
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
