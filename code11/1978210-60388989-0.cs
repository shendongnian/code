    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    
    namespace API.Middlewares
    {
        /// <summary>
        /// Custom Exception middleware to catch unhandled exception during runtime
        /// </summary>
        public class ExceptionMiddleware
        {
            private readonly RequestDelegate _next;
            private readonly ILogger<ExceptionMiddleware> _logger;
    
            public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
            {
                _logger = logger;
                _next = next;
            }
    
            public async Task InvokeAsync(HttpContext httpContext)
            {
                try
                {
                    // next request in pipeline
                    await _next(httpContext);
                }
                catch (Exception ex)
                {
                    // Logs your each error
                    _logger.LogError($"Something went wrong: {ex}");
                    await HandleExceptionAsync(httpContext, ex);
                }
            }
    
            /// <summary>
            /// Handle runtime error
            /// </summary>
            /// <param name="context"></param>
            /// <param name="exception"></param>
            /// <returns></returns>
            private Task HandleExceptionAsync(HttpContext context, Exception exception)
            {
                // Customise it to handle more complex errors
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
    
                return context.Response.WriteAsync($"Something went wrong: {exception.Message}");
            }
        }
    }
