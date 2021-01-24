    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    namespace TestError.Infrastructure
    {
        public class ErrorHandler
        {
            private readonly RequestDelegate _next;
            public ErrorHandler(RequestDelegate next)
            {
                _next = next;
            }
            public async Task Invoke(HttpContext context)
            {
                try
                {
                    await _next(context);
                    //  Handle specific HTTP status codes
                    switch (context.Response.StatusCode)
                    {
                        case 404:
                        HandlePageNotFound(context);
                        break;
                        default:
                        break;
                    }
                }
                catch (Exception e)
                {
                    //  Handle uncaught global exceptions (treat as 500 error)
                    HandleException(context, e);
                }
                finally
                {
                }
            }
            //    500
            private static void HandleException(HttpContext context, Exception e)
            {
                var statusCode = HttpStatusCode.InternalServerError;  // 500
                context.Response.StatusCode = (int)statusCode;
                context.Response.Redirect("/Error");
            }
            //  404
            private static void HandlePageNotFound(HttpContext context)
            {
                //  Log the error and serve up an information page that displays the bad url using a cookie
                string pageNotFound = context.Request.Path.ToString().TrimStart('/');
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddMilliseconds(10000);
                cookieOptions.IsEssential = true;
                context.Response.Cookies.Append("PageNotFound", pageNotFound, cookieOptions);
                context.Response.Redirect("/PageNotFound");
            }
        }
    }
