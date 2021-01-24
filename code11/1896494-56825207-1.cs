    public class Startup
    {
        ...
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            ...
            app.UseStaticFiles();
            Routing.Include(app);
            ...
        }
    }
