    services.AddSignalR()
        .AddJsonProtocol(options =>
        {
            options.SerializerSettings.Converters.Add(new StringEnumConverter(true));
        });
