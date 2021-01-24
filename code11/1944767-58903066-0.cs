    if(config.useConsole) {
        builder.RegisterType<ConsoleTenantResolverStrategy>()
               .As<ITenantIdentificationStrategy>()
               .SingleInstance();
    } else {
        builder.RegisterType<WebTenantResolverStrategy>()
               .As<ITenantIdentificationStrategy>()
               .SingleInstance();
    }
