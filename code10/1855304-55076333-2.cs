    public void Configure(IApplicationBuilder app, IHostingEnvironment env, IOptions<UploadConfig> uploadOptions)
    {
        // since the options are injected here, they will be constructed and automatically
        // validated if you have configured a validate action
        // …
        app.UseMvc();
    }
