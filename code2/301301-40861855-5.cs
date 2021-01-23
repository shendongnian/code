    builder.RegisterType<PostalServiceSender>()
               .As<ISender>()
               .WithMetadata("SendAllowed", "order");
        builder.RegisterType<EmailNotifier>()
               .As<ISender>()
               .WithMetadata("SendAllowed", "notification");
    
    builder.RegisterType<ShippingProcessor>()
               .WithParameter(
                 new ResolvedParameter(
                   (pi, ctx) => pi.ParameterType == typeof(ISender),
                   (pi, ctx) => ctx.Resolve<IEnumerable<Meta<ISender>>>()
                                   .First(a => a.Metadata["SendAllowed"].Equals("order"))));
        builder.RegisterType<CustomerNotifier>();
               .WithParameter(
                 new ResolvedParameter(
                   (pi, ctx) => pi.ParameterType == typeof(ISender),
                   (pi, ctx) => ctx.Resolve<IEnumerable<Meta<ISender>>>()
                                   .First(a => a.Metadata["SendAllowed"].Equals("notification"))));
