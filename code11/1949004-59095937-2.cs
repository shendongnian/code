    services.AddMvc()
        .AddJsonOptions(options => {
            options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            // Other changes to options.SerializerSettings ...
        });
