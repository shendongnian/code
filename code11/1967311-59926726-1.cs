    public class Startup
    {
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            IApiVersionDescriptionProvider provider,
            VersionedODataModelBuilder builder)
        {
            app.UseMiddleware<ErrorHandling>();
