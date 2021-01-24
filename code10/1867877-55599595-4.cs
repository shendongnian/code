    app2.Use(async (ctx, next) =>
    {
        var authenticateResult = await ctx.AuthenticateAsync("SchemeName");
        if (!authenticateResult.Succeeded)
        {
            ctx.Response.StatusCode = 401; // e.g.
            return;
        }
        // ...
    });
