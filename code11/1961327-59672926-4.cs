    using Microsoft.AspNetCore.Authentication.OpenIdConnect; 
    using Microsoft.AspNetCore.Authorization; 
    using Microsoft.AspNetCore.Mvc.Authorization; 
    using System.Net.Http;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.IdentityModel.Protocols.OpenIdConnect;
    using Microsoft.IdentityModel.Logging;
   
    
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddAuthorizationCore();
            services.AddSingleton<WeatherForecastService>();
                        
            services.AddAuthentication(sharedOptions =>
            {
                sharedOptions.DefaultAuthenticateScheme = 
                     CookieAuthenticationDefaults.AuthenticationScheme;
                sharedOptions.DefaultSignInScheme = 
                    CookieAuthenticationDefaults.AuthenticationScheme;
                sharedOptions.DefaultChallengeScheme = 
                   OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddOpenIdConnect("oidc", options =>
             {
                 options.Authority = "https://demo.identityserver.io/";
                 options.ClientId = "interactive.confidential.short"; 
                 options.ClientSecret = "secret";
                 options.ResponseType = "code";
                 options.SaveTokens = true;
                 options.GetClaimsFromUserInfoEndpoint = true;
                 options.UseTokenLifetime = false;
                 options.Scope.Add("openid");
                 options.Scope.Add("profile");
                 options.TokenValidationParameters = new 
                        TokenValidationParameters
                        {
                            NameClaimType = "name"
                        };
                        
                 options.Events = new OpenIdConnectEvents
                 {
                   OnAccessDenied = context =>
                            {
                              context.HandleResponse();
                              context.Response.Redirect("/");
                              return Task.CompletedTask;
                           }
           };
     });
    }
      // This method gets called by the runtime. Use this method to configure 
         the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
