csharp
services.AddAuthentication()
    .AddAzureAD(options => Configuration.Bind("AzureAd", options));
    .AddJwtBearer(otps=>{
        otps.TokenValidationParameters = new TokenValidationParameters{ ...};
    });
And then change the default Authorization Policy to authenticate those authentication schemes at the same time. For example, if you want to allow Identity/JwtBearer/AzureAd at the same time, you could do it in following way
services.AddAuthorization(opts =>{
    opts.DefaultPolicy = new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(
            IdentityConstants.ApplicationScheme     // ASP.NET Core Identity Authentication
            ,JwtBearerDefaults.AuthenticationScheme // JwtBearer Authentication
            // ,"AzureAD"                           // AzureAd Authentication
        )
        .RequireAuthenticatedUser()
        .Build();
});
Or if you want to allow only specific user/Role further, feel free to custom it by :
opts.DefaultPolicy = new AuthorizationPolicyBuilder()
    .AddAuthenticationSchemes(
        IdentityConstants.ApplicationScheme     // ASP.NET Core Identity Authentication
        ,JwtBearerDefaults.AuthenticationScheme // JwtBearer Authentication
        // ,"AzureAD"                           // AzureAd Authentication
    )
    .RequireAuthenticatedUser()
    .RequireRole(...)
    .RequireAssertion(ctx =>{
        ...
        return true_or_false;
    })
    .Build();
