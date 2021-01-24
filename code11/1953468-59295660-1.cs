    app.UseStatusCodePages(async context =>
    {
        if (context.HttpContext.Response.StatusCode == 401)
        {
            context.HttpContext.Response.Redirect("Errors/Unauthorized/");
        }
        else if (context.HttpContext.Response.StatusCode == 500)
        {
            // TODO: Redirect for 500 and so on...
        }
     });
