public static IServiceCollection AddJWTAuth(this IServiceCollection services)
{
    var cache = services.BuildServiceProvider().GetRequiredService<IMemoryCache>()
    services.AddAuthentication(options=>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(jwt =>
    {
        jwt .TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKeyResolver = (token, securityToken, keyIdentifier, tokenValidationParameters) =>
            {
               cache..GetOrCreate(...);
            }
        };
    });
    return services;
}
