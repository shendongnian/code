    app.UseAuthentication();
    app.Use(async (context, next) =>
    {
        var principal = new ClaimsPrincipal();
        var result1 = await context.AuthenticateAsync("MyScheme");
        if (result1?.Principal != null)
        {
            principal.AddIdentities(result1.Principal.Identities);
        }
        var result2 = await context.AuthenticateAsync("MyScheme2");
        if (result2?.Principal != null)
        {
            principal.AddIdentities(result2.Principal.Identities);
        }
        context.User = principal;
        await next();
    });
