    public void ConfigureServices(IServiceCollection services) {
        //...
        service.AddScoped<IEmployeeProvider, EmployeeProvider>();
        services.AddAuthorization((options, sp> => {
            IEmployeeProvider employeeProvider = sp.GetRequiredService<IEmployeeProvider>();
            options.AddPolicy("Founders", policy =>
                policy.RequireClaim("EmployeeNumber", employeeProvider.GetAuthorizedEmployeeIds())
            );
        });
        
        //...
    }
    
