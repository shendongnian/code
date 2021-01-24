    public static class ServiceCollectionExtensions
    {
       
        public static void RegisterYourLibrary(this IServiceCollection services, DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }
            services.AddScoped<IUnitOfWork, UnitOfWork>(uow => new UnitOfWork(dbContext));
        }
    }
