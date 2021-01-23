    container.RegisterTypes(AllClasses.FromAssemblies(typeof(Ping).Assembly),
       WithMappings.FromAllInterfaces,
       GetName,
       GetLifetimeManager);
    
    /* later down */
    
    static bool IsNotificationHandler(Type type)
    {
        return type.GetInterfaces().Any(x => x.IsGenericType && (x.GetGenericTypeDefinition() == typeof(INotificationHandler<>) || x.GetGenericTypeDefinition() == typeof(IAsyncNotificationHandler<>)));
    }
    
    static LifetimeManager GetLifetimeManager(Type type)
    {
        return IsNotificationHandler(type) ? new ContainerControlledLifetimeManager() : null;
    }
    
    static string GetName(Type type)
    {
        return IsNotificationHandler(type) ? string.Format("HandlerFor" + type.Name) : string.Empty;
    }
