    services.AddMvc(mvcOptions => {
        var serviceProvider = services.BuildServiceProvider();
        var jsonInputLogger = serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger<DateTimeOffSetJsonInputFormatter>();
        var jsonOptions = serviceProvider.GetRequiredService<IOptions<MvcJsonOptions>>().Value;
        var charPool = serviceProvider.GetRequiredService<ArrayPool<char>>();
        var objectPoolProvider = serviceProvider.GetRequiredService<ObjectPoolProvider>();
        var customJsonInputFormatter = new DateTimeOffSetJsonInputFormatter(
                    jsonInputLogger,
                    jsonOptions.SerializerSettings,
                    charPool,
                    objectPoolProvider,
                    mvcOptions,
                    jsonOptions
            );
        mvcOptions.InputFormatters.Insert(0, customJsonInputFormatter);
    })
    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
