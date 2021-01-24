    [assembly: WebJobsStartup(typeof(AutoFacFunctionAppPrototype.WebJobsStartup))]
    
    namespace AutoFacFunctionAppPrototype
    {
        public class WebJobsStartup : IWebJobsStartup
        {
            public void Configure(IWebJobsBuilder builder) =>
                builder.AddDependencyInjection<AutoFacServiceProviderBuilder>();
        }
    }
