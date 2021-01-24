    services.AddSimpleInjector(container, options =>
    {
        options
            .AddAspNetCore()
            .AddControllerActivation()
            .AddViewComponentActivation()
            .AddPageModelActivation()
            .AddTagHelperActivation();
        });
        services.EnableSimpleInjectorCrossWiring(container);
        services.UseSimpleInjectorAspNetRequestScoping(container);
