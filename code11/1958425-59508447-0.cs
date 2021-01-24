    public void ConfigureServices(IServiceCollection services)
    {         
        services.AddHttpContextAccessor();
        services.AddTransient<IAuthorizationHandler, MyAuthorizationHandler>();
           
        services.AddControllersWithViews(config =>
        {
            var policy = new AuthorizationPolicyBuilder()
                    .AddRequirements(new MyRequirement(MyParams))
                .Build();
            config.Filters.Add(new AuthorizeFilter(policy));
        });
           
        services.AddDbContext<MvcProj3Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MvcProj3Context")));
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
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
