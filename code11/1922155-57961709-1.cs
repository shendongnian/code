    public static IServiceCollection AddExternalCompanyClient(this IServiceCollection services) =>
        services
            .AddTransient<ExternalCompanyClient>()
            .AddTransient<IExternalCompanyClient>(sp => sp.GetRequiredService<ExternalCompanyClient>())
            .AddTransient<IService<ExternalCompanyRequest, ExternalCompanyResponse>>(sp => 
                sp.GetRequiredService<ExternalCompanyClient>()
            );
