    services.AddAuthorization(options =>
            {
                options.AddPolicy(PolicyConstants.Admin, policy =>
                {
                    // Allowed to access the resource if role admin or manager
                    policy.RequireClaim(JwtClaimTypes.Role, new[] { PolicyConstants.Admin, PolicyConstants.Manager });
                    
                   // Or use LINQ here
                    policy.RequireAssertion(c =>
                    {
                      
                        // c.User.Claims
                    });
    }
