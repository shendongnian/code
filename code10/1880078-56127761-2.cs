    services.AddApiVersioning(o =>
    {
        o.ReportApiVersions = true;
        o.AssumeDefaultVersionWhenUnspecified = true;
        o.DefaultApiVersion = new ApiVersion(1, 0);
        o.Conventions.Controller<ValuesController>().HasApiVersion(new ApiVersion(1, 0));
        o.Conventions.Controller<ValuesV1Controller>().HasApiVersion(new ApiVersion(2, 0));
    });
