    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var messages = context.ModelState.Values
                .Where(x => x.ValidationState == ModelValidationState.Invalid)
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage)
                .ToList();
            return new BadRequestObjectResult(
                Attempt<string>.Fail(
                    new AttemptException(string.Join($"{Environment.NewLine}", messages))));
        };
    })
