        public static IServiceCollection AddChained<TService>(this IServiceCollection services, params Type[] implementationTypes)
        {
            if (implementationTypes.Length == 0)
            {
                throw new ArgumentException("Pass at least one implementation type", nameof(implementationTypes));
            }
            foreach(Type type in implementationTypes)
            {
                services.AddScoped(type);
            }
            int order = 0;
            services.AddTransient(typeof(TService), provider =>
            {
                //starts again
                if (order > implementationTypes.Length - 1)
                {
                    order = 0;
                }
                Type type = implementationTypes[order];
                order++;
                return provider.GetService(type);
            });
            return services;
        }
