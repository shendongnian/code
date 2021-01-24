        public static class YourDomainDIExtensions
        {
            public static void AddDomainDataServices(this IServiceCollection services)
            {
                services.AddDbContext<YourDbContext>(...);
                services.AddTransient<YourDomainRepository>();
            }
        }
