    public static IMvcBuilder AddControllersAsServices(this IMvcBuilder builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }
       
        var feature = new ControllerFeature();
        builder.PartManager.PopulateFeature(feature);
        
        foreach (var controller in feature.Controllers.Select(c => c.AsType()))
        {
            builder.Services.TryAddTransient(controller, controller);
        }
        
        builder.Services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());
        
        return builder;
    }
