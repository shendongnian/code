    app.UseStatusCodePages(new StatusCodePagesOptions {
        HandleAsync = async context =>
        {
            if (context.HttpContext.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                await context.HttpContext.Response.WriteAsync($"{context.HttpContext.Request.Path} is not Found");
            }
        }
    });
