using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
namespace WebApplication1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            var options = new RewriteOptions()
                .Add(RedirectJsonFileRequests);
            app.UseRewriter(options);
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
        /// <summary>
        /// Redirect all requests to .json extension files to .ashx extensions, copy across the query string, if any
        /// </summary>
        /// <param name="context"></param>
        public static void RedirectJsonFileRequests(RewriteContext context)
        {
            var request = context.HttpContext.Request;
            // Because the client is redirecting back to the same app, stop 
            // processing if the request has already been redirected.
            if (request.Path.Value.EndsWith(".ashx", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
            if (request.Path.Value.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
            {
                var response = context.HttpContext.Response;
                response.StatusCode = StatusCodes.Status301MovedPermanently;
                context.Result = RuleResult.EndResponse;
                response.Headers[HeaderNames.Location] =
                    request.Path.Value.Replace(".json", ".ashx", StringComparison.OrdinalIgnoreCase) + request.QueryString;
            }
        }
    }
}
  [1]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/url-rewriting?view=aspnetcore-3.1
  [2]: https://stackoverflow.com/q/43413226/1690217
