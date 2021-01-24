    app.UseStatusCodePages(async context => {
        if(context.HttpContext.Response.StatusCode == 400)
        {
            context.HttpContext.Response.Redirect("~/Views/Shared/Errors/AccessDenied.cshtml");
        }
        else if (context.HttpContext.Response.StatusCode == 404)
        {
            context.HttpContext.Response.Redirect("~/Views/Shared/Errors/NotFound.cshtml");
        }
    });
