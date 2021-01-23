    container.AddFacility<WcfFacility>(
        f =>
            {
                f.Services.AspNetCompatibility = 
                    AspNetCompatibilityRequirementsMode.Allowed;
                f.CloseTimeout = TimeSpan.Zero;
            });
    container.Register(
        Component
            .For<IMyService>()
            .ImplementedBy<MyService>()
            .AsWcfService(new DefaultServiceModel()
                             .AddEndpoints(WcfEndpoint.BoundTo(new WebHttpBinding()))
                             .Hosted()
                             .PublishMetadata())
            .AddServiceRoute("MyService", new DefaultServiceHostFactory(), null));
