using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyProject.Interfaces;
namespace MyProject.Middlewares
{
    public class ErrorReporterMiddleware
    {
        private readonly RequestDelegate RequestDelegate;
        public ErrorReporterMiddleware(RequestDelegate requestDelegate)
        {
            RequestDelegate = requestDelegate ?? throw new ArgumentNullException(nameof(requestDelegate));
        }
        public async Task Invoke(HttpContext httpContext, IErrorReporter errorReporter)
        {
            try
            {
                await RequestDelegate(httpContext);
            }
            catch (Exception e)
            {
                await errorReporter?.CaptureAsync(e);
                throw;
            }
        }
    }
}
In this case `IErrorReporter` is an interface I have defined in the `MyProject.Interfaces` namespace. I use it to abstract the logging service:
using System;
using System.Threading.Tasks;
namespace MyProject.Interfaces
{
    public interface IErrorReporter
    {
        Task CaptureAsync(Exception exception);
        Task CaptureAsync(string message);
    }
}
Then in the `Startup.cs` I just add the following line to the `Configure` method:
app.UseMiddleware<ErrorReporterMiddleware>();
Nothing special but I think it's a clean approach.
