    public static IServiceCollection AddStorage(this IServiceCollection services)
                {
                    return services.AddSingleton<IStorage, SessionStorage>()
                        .AddSingleton<IStorage, LocalStorage>();
                }  
