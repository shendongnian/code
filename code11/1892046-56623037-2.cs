    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
    
        services.AddAuthorization(options =>
        {
            //Policy which checks availability of single claim - Claim1
            options.AddPolicy("MyPolicy1", policy => policy.RequireClaim("Claim1"));
            //Policy which checks 2 claims with appropriate values
            options.AddPolicy("MyPolicy2", policy => {
                policy.RequireClaim("Claim2", "ClaimValue2");
                policy.RequireClaim("Claim3", "ClaimValue3"));
            }
        });
    }
