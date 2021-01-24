    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    services.AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    });
