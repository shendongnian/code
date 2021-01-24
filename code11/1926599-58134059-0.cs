    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace PEG.Api.Middleware
    {
        public class CustomHeader
        {
            private readonly RequestDelegate _next;
    
            public CustomHeader(RequestDelegate next)
            {
                _next = next;
            }
    
            public async Task Invoke(HttpContext context)
            {
                //you can add your stickyCookie in the dictionary
                var dictionary = new Dictionary<string, string[]>()
                {
                    /* add your sticky cookie here. An example below
                     {
                        "Access-Control-Allow-Credentials",new string[]{"true" }
                    }*/
                };
    
                //To add Headers AFTER everything you need to do this
                context.Response.OnStarting(state => {
                    var httpContext = (HttpContext)state;
                    foreach (var item in dictionary)
                    {
                        httpContext.Response.Headers.Add(item.Key, item.Value);
                    }
                    return Task.FromResult(0);
                }, context);
    
                await _next(context);
            }
        }
    }
