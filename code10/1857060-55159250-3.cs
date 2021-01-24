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
                services
        .AddDbContext<ChatContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                services.Configure<FormOptions>(options =>
                {
                    options.MultipartBodyLengthLimit = 60000000;
                });
                services.AddMvc().AddJsonOptions(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
    
                services.AddMvcCore()
                   .AddAuthorization()
                   .AddJsonOptions(options =>
                   {
                       options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                       options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                   });
                var identityServerAuthOptions = Configuration.GetSection("Identity").Get<IdentityServerAuthenticationOptions>();
    
                services.AddAuthentication("Bearer")
                    .AddIdentityServerAuthentication(options =>
                    {
                        options.Authority = identityServerAuthOptions.Authority;
                        options.RequireHttpsMetadata = identityServerAuthOptions.RequireHttpsMetadata;
                        options.ApiName = identityServerAuthOptions.ApiName;
                    });
    
    
                var settings = new JsonSerializerSettings();
                settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                settings.ContractResolver= new CamelCasePropertyNamesContractResolver();
                services.AddSignalR()
                       .AddJsonProtocol(options => {
                           options.PayloadSerializerSettings = settings;
                              });
                services.AddTransient<IUserService, UserService>();
                services.AddCors();
        }
    
            public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();
                //Data.AddData(app.ApplicationServices.GetService<ChatContext>());
                app.Use(async (context, next) =>
                {
                    if (string.IsNullOrWhiteSpace(context.Request.Headers["Authorization"]))
                    {
                        if (context.Request.QueryString.HasValue)
                        {
                            var token = context.Request.QueryString.Value.Split('&').SingleOrDefault(x => x.Contains("authorization"))?.Split('=')[1];
                            if (!string.IsNullOrWhiteSpace(token))
                            {
                                context.Request.Headers.Add("Authorization", new[] { $"Bearer {token}" });
                            }
                        }
                    }
                    await next.Invoke();
                });
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                  //  app.UseBrowserLink();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                }
    
                app.UseStaticFiles();
                app.UseAuthentication();
                app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials());
                app.UseSignalR(config =>
                {
    
                    config.MapHub<UserHub>("/UsersHub");
                });
                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                    routes.MapSpaFallbackRoute("spa-fallback", new { controller = "Home", action = "Index" });
                });
            }
        }
  
      app.UseCors(builder =>
                builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader()
               );
