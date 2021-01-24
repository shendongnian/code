    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    
    using Microsoft.Extensions.Logging;
    
    namespace temp
    {
        public class Startup
        {    
            public void Configure(IApplicationBuilder app, IHostEnvironment env, ILogger<Startup> logger)
            {
                ...
    
                app.UseStatusCodePages(async context =>
                {
                    var code = context.HttpContext.Response.StatusCode;
                    if (code == 404) {
                        logger.Log(LogLevel.Error, new Exception(), "log message");
                    }
                });
    
                ...
            }
        }
    }
