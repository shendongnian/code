    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMyService(this IServiceCollection services, Func<RequestContext> callBack = null)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IMyService, MyService>(sp => new MyService(new HttpContextAccessor(), new Func<RequestContext>(target)));
            return services;
        }
    }
