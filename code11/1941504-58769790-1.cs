    public void Configure(IApplicationBuilder app)
    {
       app.UseRouting();   // Routes middleware
    
       // Request body-reading middleware must be put after UseRouting()
       app.Use(async (ctx, next) =>
       {
          var endpoint = ctx.GetEndpoint();
    
          if (endpoint != null)
          {
             var attribute = endpoint.Metadata.GetMetadata<ThierryAttribute>();
    
                if (attribute != null)
                {
                   ctx.Request.EnableBuffering();
    
                   using (var sr = new StreamReader(ctx.Request.Body, Encoding.UTF8, false, 1024, true))
                   {
                      var str = await sr.ReadToEndAsync();   // Store request body JSON string
                   }
    
                   ctx.Request.Body.Position = 0;
                }
          }
    
          await next();
       });
    
       app.UseEndpoints(erb => erb.MapControllers());   // Controller middleware
    }
