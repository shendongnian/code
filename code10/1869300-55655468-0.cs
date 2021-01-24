    services.Configure<ApiBehaviorOptions>(options =>
    {
        options.InvalidModelStateResponseFactory = actionContext => 
        {
            var errors = actionContext.ModelState
                .Where(e => e.Value.Errors.Count > 0)
                .Select(e => new Error
                {
                Name = e.Key,
                Message = e.Value.Errors.First().ErrorMessage
                }).ToArray();
    
            return new BadRequestObjectResult(errors);
        }
    });
