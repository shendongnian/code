    public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime applicationLifetime)
    {
        //Register app termination event hook
        applicationLifetime.ApplicationStopping.Register(() => OnShutdown(app.ApplicationServices));
         //...do stuff...
    }
    private void OnShutdown(IServiceProvider serviceProvider)
    {
            var myService = serviceProvider.GetService<MyService>();
             myService.DoSomething();
    }
