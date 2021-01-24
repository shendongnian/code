       // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                // Add middleware before MVC
                app.Use(async (ctx, next) =>
                {
                    // Capture the original response body stream
                    var responseStream = ctx.Response.Body;
    
                    // Replace it with our own, so that we can read it
                    using (var bodyStream = new MemoryStream())
                    {
                        ctx.Response.Body = bodyStream;
    
                  
                        // Run ASP.NET MVC (ie. get the results back from your code)
                        await next();
    
                        // Put the original response body stream back
                        ctx.Response.Body = responseStream;
                     
                        // Read the one that we captured
                        bodyStream.Seek(0, SeekOrigin.Begin);
                        var responseBody = await new StreamReader(bodyStream).ReadToEndAsync();
    
                        // If it's ODATA & JSON & 200 (success), replace the "value" with "results"
                        if (ctx.Response.ContentType.Contains("application/json") && ctx.Response.ContentType.Contains("odata") && ctx.Response.StatusCode == 200)
                        {
                            responseBody = responseBody.Replace("\"value\"", "\"results\"");
                        }
    
                        // Write back the response body (whether modified or not) to the original response stream
                        await ctx.Response.WriteAsync(responseBody);
                    }
                });
