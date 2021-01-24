    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    
    namespace Onsolve.ONE.WebApi.Middlewares
    {
        public sealed class RequestHandlerMiddleware
        {
            private readonly RequestDelegate next;
            private readonly ILogger logger;
    
            public RequestHandlerMiddleware(ILogger<RequestHandlerMiddleware> logger, RequestDelegate next)
            {
                this.next = next;
                this.logger = logger;
            }
    
            public async Task Invoke(HttpContext context)
            {
                logger.LogInformation($"Header: {JsonConvert.SerializeObject(context.Request.Headers, Formatting.Indented)}");
    
                context.Request.EnableBuffering();
                var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
                logger.LogInformation($"Body: {body}");
                context.Request.Body.Position = 0;
    
                logger.LogInformation($"Host: {context.Request.Host.Host}");
                logger.LogInformation($"Client IP: {context.Connection.RemoteIpAddress}");
                await next(context);
            }
    
        }
    }
