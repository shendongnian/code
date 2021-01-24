    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddMvc()
            .AddJsonOptions(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            )
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    
        services.AddGraphQL(x =>
        {
            x.ExposeExceptions = true; //set true only in development mode. make it switchable.
        })
        .AddGraphTypes(ServiceLifetime.Scoped);
    }
    
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, Seeder seeder)
    {
        app.UseGraphQL<DataSchema>();
        app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
    
        app.UseMvc(routes =>
        {
            routes.MapRoute(
                name: "default",
                template: "{controller}/{action=Index}/{id?}");
        });
    }
