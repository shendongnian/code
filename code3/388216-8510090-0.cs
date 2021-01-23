    container.Register(AllTypes
                       .FromThisAssembly()
                       .InSameNamespaceAs<IMyService>()
                       .WithServiceDefaultInterfaces()
                       .ConfigureIf(s => typeof(IMyService).IsAssignableFrom(s.Implementation),
                                    s => s.LifestyleSingleton(),
                                    s => s.LifestyleTransient()));
