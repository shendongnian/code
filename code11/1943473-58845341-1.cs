c#
public void ConfigureServices(IServiceCollection services) 
{
           //Code above . . .
            services.AddMvc( options =>
            {
                options.EnableEndpointRouting = false;
            });
            //Code below. . .
}
and then in 
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Code above . . .
            app.UseMvcWithDefaultRoute();
            //Code below. . .
        }
and remove 
c#
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapRazorPages();
    });`
