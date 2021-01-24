    services.AddMvc().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new ErrorIgnoringJsonConverter<bool>());
                options.SerializerSettings.Converters.Add(new ErrorIgnoringJsonConverter<int>());
                options.SerializerSettings.Converters.Add(new ErrorIgnoringJsonConverter<long>());
                options.SerializerSettings.Converters.Add(new ErrorIgnoringJsonConverter<float>());
                options.SerializerSettings.Converters.Add(new ErrorIgnoringJsonConverter<double>());
                options.SerializerSettings.Converters.Add(new ErrorIgnoringJsonConverter<decimal>());
                options.SerializerSettings.Converters.Add(new ErrorIgnoringJsonConverter<DateTime>());
            });
