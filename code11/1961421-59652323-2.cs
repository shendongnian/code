    services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DictionaryConverterFactory());
        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });
