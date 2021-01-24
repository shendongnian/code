    public class Startup 
    {
       public Startup(IConfiguration configuration, IWebHostEnvironment env)
       {
                Configuration = configuration;
                Environment = env;
       }
    
       public Microsoft.AspNetCore.Hosting.IWebHostEnvironment Environment { get; }
    
       public void ConfigureServices(IServiceCollection services)
       {
                services.AddControllers(opts =>
                {
                    if (Environment.IsDevelopment())
                    {
                        opts.Filters.Add<AllowAnonymousFilter>();
                    }
                    else
                    {
                      var authenticatedUserPolicy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                      opts.Filters.Add(new AuthorizeFilter(authenticatedUserPolicy)); 
                     }
                });
        }
    
    } 
