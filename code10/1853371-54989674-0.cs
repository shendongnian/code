      services.AddOptions<EventsSettings>()
                    .Bind(Configuration.GetSection("Settings"))
                    .ValidateDataAnnotations();
    
      // Register the EventsSetting service using the factory overload
      services.AddTransient(srv => srv.GetService<IOptions<EventsSettings>>().Value);
