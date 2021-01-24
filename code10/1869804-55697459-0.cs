        app.UseSwagger(options =>
        {
            options.RouteTemplate = "api/docs/{documentName}/swagger.json";
        });
        app.UseSwaggerUI
        (
            options =>
            {
                options.DocumentTitle = "...";
                options.RoutePrefix = "api/docs";
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"{description.GroupName}/swagger.json", "API " + description.GroupName.ToUpperInvariant() + " Specs");
                }
            }
        );
