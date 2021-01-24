    public class Startup
    {
        ...
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePagesWithReExecute("/error/{0}");
            ...
        }
    }
