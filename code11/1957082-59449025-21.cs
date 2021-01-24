    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.Extensions.Configuration;
    
    namespace stackoverflow_aspnetcore_59448960
    {
        public class Startup
        {
            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }
    
            public IConfiguration Configuration { get; }
    
            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
                // Does automatically collect all routes.
                services.AddRazorPages();
    
                services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        // That will point to /Pages/Login.cshtml
                        options.LoginPath = "/Login/Index";
                    }); ;
    
                services.AddAuthorization(options =>
                {
                    // This says, that all pages need AUTHORIZATION. But when a controller, 
                    // for example the login controller in Login.cshtml.cs, is tagged with
                    // [AllowAnonymous] then it is not in need of AUTHORIZATION. :)
                    options.FallbackPolicy = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build();
                });
            }
    
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
    
                app.UseAuthorization();
    
                app.UseEndpoints(endpoints =>
                {
                    // Defines default route behaviour.
                    endpoints.MapRazorPages();
                });
            }
        }
    }
