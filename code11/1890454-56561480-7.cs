    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            var resolver = config.DependencyResolver; //Assuming one is set.
            var basicAuth = resolver.GetService(typeof(BasicAuthenticationAttribute)) as BasicAuthenticationAttribute;
            // Web API configuration and services
            config.Filters.Add(basicAuth);
            //...omitted for brevity
