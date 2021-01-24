c#
            services.AddMvc( options =>
            {
                options.EnableEndpointRouting = false;
            });
and then in your `public void Configure(IApplicationBuilder app)` method try calling 
app.UseMvcWithDefaultRoute();
and remove 
c#
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapRazorPages();
    });`
