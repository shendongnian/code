builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
Assembly serviceLayerAssembly = typeof(IUserServices).Assembly;
            builder.RegisterAssemblyTypes(assemblies: serviceLayerAssembly)
                .AssignableTo<IMarkedServiceInterface>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(assemblies: serviceLayerAssembly)
                .AssignableTo<IMarkedMapperInterface>().AsImplementedInterfaces().InstancePerLifetimeScope();
