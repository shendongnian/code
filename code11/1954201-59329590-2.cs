    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
    
        app.UseHttpsRedirection();
    
        app.UseRouting();
    
        app.Use(async (httpContext, next) =>
        {
            var endpointMetaData = httpContext.GetEndpoint()
                .Metadata;
    
            bool hasCustomAuthorizeAttribute = endpointMetaData.Any(x => x is CustomAuthorizeAttribute);
    
            if (hasCustomAuthorizeAttribute)
            {
                // get the endpoint's instance of CustomAuthorizeAttribute
                CustomAuthorizeAttribute customAuthorieAttribute = endpointMetaData
                    .FirstOrDefault(x => x is CustomAuthorizeAttribute) as CustomAuthorizeAttribute;
    
                // here you will have access to customAuthorizeAttribute.AllowedUserRoles
                // and can execute your custom logic with it
                bool isAuthorized = true;
    
                if (isAuthorized)
                {
                    // continue processing the request
                    await next.Invoke();
                }
                else
                {
                    // stop processing request and return unauthorized response
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    await httpContext.Response.WriteAsync("Unauthorized");
                }
            }
        });
    
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
