    namespace Ocelot.Middleware
    {
    
        //...
    
        public static class OcelotMiddlewareExtensions
        {
            public static async Task<IApplicationBuilder> UseOcelot(this IApplicationBuilder builder)
            {
                await builder.UseOcelot(new OcelotPipelineConfiguration());
                return builder;
            }
    
        //...
