    using Microsoft.Azure.Functions.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection;
    [assembly: FunctionsStartup(typeof(MyNamespace.Gateway.Queue.Function.Startup))]
    namespace MyNamespace.Gateway.Queue.Function
    {
        public class Startup : FunctionsStartup
        {
            public override void Configure(IFunctionsHostBuilder builder)
            {
                builder.Services.AddSolutionServices();
            }
        }
    }
