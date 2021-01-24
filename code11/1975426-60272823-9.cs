    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePagesWithReExecute("/Status/{0}");
            app.UseExceptionHandler("/Status");
        }
        else
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePagesWithReExecute("/Status/{0}");
            app.UseExceptionHandler("/Status");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.Use(async (context, next) =>
        {
            await next();
            if (context.Response.StatusCode == 401)
            {
                var newPath = new PathString("/Status/401");
                var originalPath = context.Request.Path;
                var originalQueryString = context.Request.QueryString;
                context.Features.Set<IStatusCodeReExecuteFeature>(new StatusCodeReExecuteFeature()
                {
                    OriginalPathBase = context.Request.PathBase.Value,
                    OriginalPath = originalPath.Value,
                    OriginalQueryString = originalQueryString.HasValue ? originalQueryString.Value : null,
                });
                // An endpoint may have already been set. Since we're going to re-invoke the middleware pipeline we need to reset
                // the endpoint and route values to ensure things are re-calculated.
                context.SetEndpoint(endpoint: null);
                var routeValuesFeature = context.Features.Get<IRouteValuesFeature>();
                routeValuesFeature?.RouteValues?.Clear();
                context.Request.Path = newPath;
                try
                {
                    await next();
                }
                finally
                {
                    context.Request.QueryString = originalQueryString;
                    context.Request.Path = originalPath;
                    context.Features.Set<IStatusCodeReExecuteFeature>(null);
                }
                // which policy failed? need to inform consumer which requirement was not met
                //await next();
            }
        });
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
        });
    }
