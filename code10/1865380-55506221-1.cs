    ContextKey key = //known value
    
    //...Assumes IIndex<ContextKey, IDbContextBase> factory is registered
    
    builder
        .RegisterGeneric(typeof(BaseRepository<>))
        .As(typeof(IBaseRepository<>))
        .WithParameter(
            new ResolvedParameter(
                (pi, ctx) => pi.ParameterType == typeof(IDbContextBase) && pi.Name == "context",
                (pi, ctx) => {
                    var factory = ctx.Resolve<IIndex<ContextKey, IDbContextBase>>();
                    return factory[key];
                })
        );
    //...
    var container = builder.Build();
