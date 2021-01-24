    public void ConfigureServices(IServiceCollection services)
    {
        ...
        services.AddAuthorization(options =>
        {
            options.AddPolicy("ShouldHaveMerchantId", policy => 
                  policy.RequireClaim("merchant_id"));
        });
        ...
    }
