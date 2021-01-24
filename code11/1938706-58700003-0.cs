    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.UseResponseCompression();
        app.UseFetchLocaleMiddleware();     
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHsts();
        }
    
        app.UseGraphQL<SampleTestSchema>();
        app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());      
        
        app.UseMvc();
    }
