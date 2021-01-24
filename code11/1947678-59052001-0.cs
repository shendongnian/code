    public void Configure(IApplicationBuilder app)
    {           
        app.Map("/metrics", innerApp =>
        {
            innerApp.UseMetricsMiddleware());
            innerApp.UseMetricServer();
        }
    }
