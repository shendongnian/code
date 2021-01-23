    Container
     .RegisterType<ConfigurationStore, ConfigurationStore>
                                  (
                                     new ContainerControlledLifetimeManager()
                                   , new InjectionConstructor(typeof(ITypeMapFactory)
                                   , MapperRegistry.AllMappers())
                                  )
     .RegisterType<IConfigurationProvider, ConfigurationStore>()
     .RegisterType<IConfiguration, ConfigurationStore>()
     .RegisterType<IMappingEngine, MappingEngine>()
     .RegisterType<ITypeMapFactory, TypeMapFactory>();
