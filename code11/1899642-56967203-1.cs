    services.AddSimpleInjector(container, options =>
    {
        options
            .AddAspNetCore()
            .AddControllerActivation()
            .AddViewComponentActivation()
            .AddPageModelActivation()
            .AddTagHelperActivation();
        });
