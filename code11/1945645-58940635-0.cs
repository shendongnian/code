    var cachePeriod = env.IsDevelopment() ? "600" : "2592000";
    app.UseStaticFiles(new StaticFileOptions
    {
        OnPrepareResponse = ctx =>
        {
            ctx.Context.Response.Headers.Append("Cache-Control", $"public, max-age={cachePeriod}");
        },
        ServeUnknownFileTypes = true
