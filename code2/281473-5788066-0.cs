        var ctx = Container.Resolve<IComponentContext>();
        var taskNames = ctx.ComponentRegistry.Registrations
            .Select(c => c.Services.FirstOrDefault() as KeyedService)
            .Where(s => s != null && s.ServiceType == typeof (TaskParameters))
            .Select(s => s.ServiceKey).ToList();
