    app.UseRouting();
    app.Use(async (ctx, next) =>
    {
        // using Microsoft.AspNetCore.Http;
        var endpoint = ctx.GetEndpoint();
        if (endpoint != null)
        {
            // An endpoint was matched.
            // ...
        }
        await next();
    });
    app.UseEndpoints(endpoints => endpoints.MapControllers());
