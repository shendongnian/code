    builder.RegisterType<PostalServiceSender>()
               .As<ISender>()
               .Keyed<ISender>("order");
        builder.RegisterType<EmailNotifier>()
               .As<ISender>()
               .Keyed<ISender>("notification");
    
    builder.RegisterType<ShippingProcessor>()
               .WithParameter(
                 new ResolvedParameter(
                   (pi, ctx) => pi.ParameterType == typeof(ISender),
                   (pi, ctx) => ctx.ResolveKeyed<ISender>("order")));
        builder.RegisterType<CustomerNotifier>();
               .WithParameter(
                 new ResolvedParameter(
                   (pi, ctx) => pi.ParameterType == typeof(ISender),
                   (pi, ctx) => ctx.ResolveKeyed<ISender>("notification")));
