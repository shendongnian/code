    var builder = new ContainerBuilder();
    builder.Register(ctx => new ShippingProcessor(new PostalServiceSender()));
    builder.Register(ctx => new CustomerNotifier(new EmailNotifier()));
    var container = builder.Build();
    // Lambda registrations resolve based on the specific type, not the
    // ISender interface.
    builder.Register(ctx => new ShippingProcessor(ctx.Resolve<PostalServiceSender>()));
    builder.Register(ctx => new CustomerNotifier(ctx.Resolve<EmailNotifier>()));
    var container = builder.Build();
