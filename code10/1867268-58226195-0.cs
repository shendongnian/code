    _container = new UnityContainer();
    _container.RegisterInstance<ILoggerFactory>(new LoggerFactory().AddLog4Net(), new ContainerControlledLifetimeManager());
    _container.RegisterFactory(typeof(ILogger<>), null, (c, t, n) =>
            {
                var factory = c.Resolve<ILoggerFactory>();
                var genericType = t.GetGenericArguments().First();
                var mi = typeof(Microsoft.Extensions.Logging.LoggerFactoryExtensions).GetMethods().Single(m => m.Name == "CreateLogger" && m.IsGenericMethodDefinition);
                var gi = mi.MakeGenericMethod(t.GetGenericArguments().First());
                return gi.Invoke(null, new[] { factory });
            });
