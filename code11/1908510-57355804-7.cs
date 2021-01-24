    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    
    namespace TryLog4net
    {
        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            { 
            }
         
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
    
                app.Run(async (context) =>
                {
                    var testClass = new TestClass();
                    testClass.LogSomething();
                    await context.Response.WriteAsync("Hello World!");
                }); 
            }
    
            public class TestClass
            {
                public void LogSomething()
                {
                    var logger = this.Log();
                    logger.Info("my message");              
                }
            }
        }
    }
