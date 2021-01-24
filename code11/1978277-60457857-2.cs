    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            lifetime.ApplicationStopping.Register(OnStopping); // <== Magic is here!
        }
        // [Blah blah, yada yada, your super cool code here]
    }
    private void OnStopping()
    {
        // Things to do before application is stopped
    }
