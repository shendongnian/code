    services.AddApiVersioning(option =>
    {
        option.ReportApiVersions = true;
        option.AssumeDefaultVersionWhenUnspecified = true;
        option.DefaultApiVersion = new ApiVersion(1, 0);
        option.AssumeDefaultVersionWhenUnspecified = true;
    });
