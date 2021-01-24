    app.UseStatusCodePages(async context =>
            {
                var httpContext = context.HttpContext;
                var statusCode = context.HttpContext.Response.StatusCode;
                //write a custom body here       
                //for example
                await context.HttpContext.Response.WriteAsync(
                    "Status code page, status code: " +
                    statusCode);
            });
