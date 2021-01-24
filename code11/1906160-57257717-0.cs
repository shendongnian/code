    var settings = Assembly.Load(nameof(DataLayer))
        .GetTypes()
        .Where(t => t.Name.EndsWith(_sectionNameSuffix, StringComparison.InvariantCulture ) && !t.IsInterface)
        .ToList();
        settings.ForEach(type =>
        {
            builder.Register(c => c.Resolve<ISettingsReader>().LoadSection(type))
                .As(type.GetInterfaces())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        });
