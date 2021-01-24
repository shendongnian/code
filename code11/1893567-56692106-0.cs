    app.UseErrorHandler("/Home/Error");
    app.Use(async (ctx, next) =>
    {
        try
        {
            // Log the incoming request.
            await next();
            // Log the outgoing response.
        }
        catch (Exception ex)
        {
            // Log the exception.
            throw; // Rethrow. The error-handler will pick this up.
        }
    });
    // e.g.
    app.UseMvc();
