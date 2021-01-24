    builder.RegisterAssemblyTypes(persistenceAssembly)
            .Where(t => t.Name.EndsWith("Operation"))
            .AssignableTo<Base>()
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
