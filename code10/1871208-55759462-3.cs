    public static class LightCoreConfiguration
        {
          
            public static void RegisterGlobalDependencies(ContainerBuilder builder)
            {
    builder.Register<IDatabaseSessions, DatabaseSessions>();
            }
        }
    }
