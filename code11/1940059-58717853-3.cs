    public static class SetupFiltersExtensions
    {
        public static IAppBuilder SetupFilters(this IAppBuilder builder, HttpConfiguration config)
        {
            config.Services.Replace(typeof (IExceptionHandler), new GlobalExceptionHandler());
             
            return builder;
        }
    }
