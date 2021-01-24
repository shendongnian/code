    public static class MyAwesomeLibraryExtensions
    {
        public static void AddMyAwesomeLibrary(this IServiceCollection services)
        {
            services.AddSingleton<SomeSingleton>();
            services.AddTransient<SomeTransientService>();
        }
    }
