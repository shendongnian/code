    // Public Docs Api
    app.UseSwaggerUI(c =>
    {
        // we use absolute uri here, since the swagger.json is outside of this application
        c.SwaggerEndpoint("http://example.com/api-docs/public/swagger.json", "Public API");
    });
    // Private Docs App
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("http://example.com/api-docs/private/swagger.json", "Private API");
    });
