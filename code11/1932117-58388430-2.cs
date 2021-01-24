        services.AddMvc(o =>
        {
                var serviceProvider = services.BuildServiceProvider();
                var customJsonInputFormatter = new MyJsonInputFormatter(
                                serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger<MyJsonInputFormatter>(),
                                serviceProvider.GetRequiredService<IOptions<MvcJsonOptions>>().Value.SerializerSettings,
                                serviceProvider.GetRequiredService<ArrayPool<char>>(),
                                serviceProvider.GetRequiredService<ObjectPoolProvider>(),
                                o,
                                serviceProvider.GetRequiredService<IOptions<MvcJsonOptions>>().Value
                        );
                o.InputFormatters.Insert(0, customJsonInputFormatter);
        })
