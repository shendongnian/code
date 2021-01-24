    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ISampleData sampleData)
    {
        // …
        sampleData.Initialize();
    }
