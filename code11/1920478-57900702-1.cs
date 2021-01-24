        services.AddMvc(opt => {
            var serviceProvider = services.BuildServiceProvider();
            var modelStateJsonInputFormatter = new ModelStateJsonInputFormatter(
                        serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger<ModelStateJsonInputFormatter>(),
                        serviceProvider.GetRequiredService<IOptions<MvcJsonOptions>>().Value.SerializerSettings,
                        serviceProvider.GetRequiredService<ArrayPool<char>>(),
                        serviceProvider.GetRequiredService<ObjectPoolProvider>(),
                        opt,
                        serviceProvider.GetRequiredService<IOptions<MvcJsonOptions>>().Value
                );
            opt.InputFormatters.Insert(0, modelStateJsonInputFormatter);
        }).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest);
