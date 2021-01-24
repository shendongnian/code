        services.AddScoped(sp =>
        {
            var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();
            var serviceForTenantFactory = new ServiceForTenantFactory(); // Or use DI.
            return serviceForTenantFactory.Create(httpContextAccessor.HttpContext);
        });
