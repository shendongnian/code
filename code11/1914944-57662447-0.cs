c#
public IServiceProvider ConfigureServices(IServiceCollection services)
        {
          services.AddAuthentication()
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        // The application URL is used for the Issuer and Audience and is included in the appsettings.json
                        ValidIssuer = _appConfiguration["Authentication:JwtBearer:Issuer"],
                        ValidAudience = _appConfiguration["Authentication:JwtBearer:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]))
                    };
                });
             // Activate Cookie Authentication without Identity, since Abp already implements Identity below.
             services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/Login");
             // Add the Authentication Scheme Provider which will set the authentication method based on the kind of request. i.e API or MVC
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IAuthenticationSchemeProvider, CustomAuthenticationSchemeProvider>();
             // Some of these extensions changed
             services.AddAbpIdentity<Tenant, User, Role>()
            .AddUserManager<UserManager>()
            .AddRoleManager<RoleManager>()
            .AddSignInManager<SignInManager>()
            .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory>()
            .AddDefaultTokenProviders();
//…
}
public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
// app.UseAuthentication is critical here
            app.UseAuthentication();
            app.UseAbp(); //Initializes ABP framework.
            app.UseCors("CorsPolicy");
//…
 //AuthConfigurer.Configure(app, _appConfiguration);
//…
         }
}
public class CustomAuthenticationSchemeProvider : AuthenticationSchemeProvider
{
    private readonly IHttpContextAccessor httpContextAccessor;
    public CustomAuthenticationSchemeProvider(
        IHttpContextAccessor httpContextAccessor,
        IOptions<AuthenticationOptions> options)
        : base(options)
    {
        this.httpContextAccessor = httpContextAccessor;
    }
    private async Task<AuthenticationScheme> GetRequestSchemeAsync()
    {
        var request = httpContextAccessor.HttpContext?.Request;
        if (request == null)
        {
            throw new ArgumentNullException("The HTTP request cannot be retrieved.");
        }
        // For API requests, use authentication tokens.
        var authHeader = httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
        if (authHeader?.StartsWith("Bearer ") == true)
        {
            return await GetSchemeAsync(JwtBearerDefaults.AuthenticationScheme);
        }
        // For the other requests, return null to let the base methods
        // decide what's the best scheme based on the default schemes
        // configured in the global authentication options.
        return null;
    }
    public override async Task<AuthenticationScheme> GetDefaultAuthenticateSchemeAsync() =>
        await GetRequestSchemeAsync() ??
        await base.GetDefaultAuthenticateSchemeAsync();
    public override async Task<AuthenticationScheme> GetDefaultChallengeSchemeAsync() =>
        await GetRequestSchemeAsync() ??
        await base.GetDefaultChallengeSchemeAsync();
    public override async Task<AuthenticationScheme> GetDefaultForbidSchemeAsync() =>
        await GetRequestSchemeAsync() ??
        await base.GetDefaultForbidSchemeAsync();
    public override async Task<AuthenticationScheme> GetDefaultSignInSchemeAsync() =>
        await GetRequestSchemeAsync() ??
        await base.GetDefaultSignInSchemeAsync();
    public override async Task<AuthenticationScheme> GetDefaultSignOutSchemeAsync() =>
        await GetRequestSchemeAsync() ??
        await base.GetDefaultSignOutSchemeAsync();
}
