    using Microsoft.Azure.Functions.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    [assembly: FunctionsStartup(typeof(MyFunctionApp.MyFunctionAppStartup))]
    namespace MyFunctionApp
    {
        public class MyFunctionApp : FunctionsStartup
        {
            public override void Configure(IFunctionsHostBuilder builder)
            {
                builder.Services.AddTransient<MySqlDatabase>((s) =>
                {
                    return new MySqlDatabase(Environment.GetEnvironmentVariable("MyFunctionApp-DbConn"));
                });
                builder.Services.AddSingleton<ServiceQueries>();
            }
        }
    }
