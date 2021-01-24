    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            var kernel = NinjectWebCommon.CreateKernel();
            // Web API configuration and services
            config.Filters.Add(kernel.Get<BasicAuthenticationAttribute>());
            //...omitted for brevity
