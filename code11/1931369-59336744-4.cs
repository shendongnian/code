    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        // ...
        public void ConfigureServices(IServiceCollection services)
        {
            // ...
            services.AddIdentityServer()
                .AddApiAuthorization<User, ApplicationDbContext>(options =>
                {
                    // The options.ApiResources collection is automatically populated
                    // by services.AddAuthentication().AddIdentityServerJwt();
                    var apiResource = options.ApiResources[$"{Environment.ApplicationName}API"];
                    // Example: add the user's roles to the token
                    apiResource.UserClaims.Add(JwtClaimTypes.Role);
                    // Example: add another custom claim type
                    apiResource.UserClaims.Add("CustomClaimName");
                });
            services.AddAuthentication()
                .AddIdentityServerJwt();
            // ...
        }
    }
