    public void Configure(IApplicationBuilder application)
    {
        application
            // other extensions...
            .UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute())
            .UseSpa(_ => { }); // extension from 'Microsoft.AspNetCore.SpaServices.Extensions' assembly
    }
