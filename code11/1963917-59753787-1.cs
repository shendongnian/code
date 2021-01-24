    public static class ServiceCollectionExtensions
    {
       
        public static void RegisterMyLibrary(this IServiceCollection services, DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }
            services.AddScoped<IFoo, Foo>(x => new Foo(dbContext));
        }
    }
