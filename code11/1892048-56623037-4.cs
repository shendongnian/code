    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
    
        services.AddAuthorization(options =>
        {
            //Scenario 1: Policy which checks availability of single claim - Claim1
            options.AddPolicy("MyPolicy1", policy => policy.RequireClaim("Claim1"));
            
            //Scenario 2: Policy which requires 2 claims with appropriate values
            options.AddPolicy("MyPolicy2", policy => {
                policy.RequireClaim("Claim2", "ClaimValue2");
                policy.RequireClaim("Claim3", "ClaimValue3"));
            }
            
            //Scenario 3: Policy which requires one of the 2 claims with appropriate values
            options.AddPolicy("MyPolicy3", policy => {
                policy.RequireAssertion(ctx =>
                {
                  return ctx.User.HasClaim("Claim4", "ClaimValue4") ||
                         ctx.User.HasClaim("Claim5", "ClaimValue5");
                })
            }
        });
    }
