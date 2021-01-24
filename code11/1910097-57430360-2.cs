        public static void AddServiceForTenant(this IServiceCollection services)
        {
            services.AddScoped<IServiceForTenant>(sp =>
            {
                // ...
            });
        }
