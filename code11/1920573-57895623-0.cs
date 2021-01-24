     services.AddScoped<IDynamicsConnector, DynamicsConnector>();
     services.AddScoped(resolver =>
     {
          var dc = resolver.GetService<IDynamicsConnector>();
          dc.DynamicsConnectorOptions = resolver.GetService<IOptions<DynamicsConnectorOptions>>().Value;
          return dc;
     });
