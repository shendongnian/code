    public static class YourServiceExtensions
    {
        public static IServiceCollection AddYourStuff(this IServiceCollection services)
        {
            services.AddSingleton<SubdependencyOne>();
            services.AddSingleton<SubdependencyTwo>();
            services.AddSingleton<IRootA>(provider =>
            {
                var subdependency = provider.GetService<SubdependencyOne>();
                return new RootA(subdependency);
            });
            services.AddSingleton<IRootB>(provider =>
            {
                var subdependency = provider.GetService<SubdependencyTwo>();
                return new RootB(subdependency);
            });
            return services;
        }
    }
