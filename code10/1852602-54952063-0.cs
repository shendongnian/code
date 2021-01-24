    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        services.AddSingleton<IQueue, Queue>();
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, IQueue queue)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHsts();
        }
        Task.Run(() => queue.BeginProcessing());
        app.UseHttpsRedirection();
        app.UseMvc();
    }
