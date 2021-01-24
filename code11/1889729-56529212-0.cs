    // This will authenticate calling applications based on the "api-key" header
    app.UseWhen(context => context.Request.Headers.ContainsKey("api-key"), appBuilder =>
    {
        appBuilder.UseMiddleware<HmacAuthentication>();
    });
    // Using the exact opposite, makes all other requests authenticate the normal way
    app.UseWhen(context => !context.Request.Headers.ContainsKey("api-key"), appBuilder =>
    {
        appBuilder.UseAuthentication();
        appBuilder.UseIdentityServer();
    });
