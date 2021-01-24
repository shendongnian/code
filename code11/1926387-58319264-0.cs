    Bind<IViewModel>()
        .ToMethod(ctx => ctx.Kernel.Get<AlphaViewModel>())
        .WhenTargetHas<AlphaAttribute>();
    ...
    Bind<IViewModel>()
        .ToMethod(ctx => ctx.Kernel.Get<AlphaViewModel>())
        .Named("Alpha");
