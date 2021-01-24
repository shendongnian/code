    public static void AddConfigWithValidation(this IServiceCollection services, IConfiguration config)
    {
        // lazy validation
        services.Configure<TestOptions>(config.GetSection(nameof(TestOptions))).AddOptions<TestOptions>().ValidateDataAnnotations();
        var model = config.GetSection(nameof(TestOptions)).Get<TestOptions>();
        // eager validation
        var validationErrors = model.Validate(new ValidationContext(model)).ToList();
        if (validationErrors.Any())
            throw new ApplicationException($"Found {validationErrors.Count} configuration error(s): {string.Join(',', validationErrors)}");
    }
