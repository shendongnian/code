    public void Configure(IApplicationBuilder app, IHostingEnvironment env, OptionsValidator optionsValidator)
    {
        // validate options explicitly
        optionsValidator.Validate();
        // …
        app.UseMvc();
    }
