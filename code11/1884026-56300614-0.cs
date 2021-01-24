    static class MyCustomExt
    {
        public static IServiceCollection AddScopedWitInterfaces<T>(this IServiceCollection services)
        {
            Type type = typeof(T);
        
            Type[] interfaces = type.GetInterfaces();
            
            foreach (Type interfaceType in interfaces)
            {
                services.AddScoped(interfaceType, type);
            }
        
            return services;
        }
    }
