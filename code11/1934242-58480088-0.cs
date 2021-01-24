    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           //...
            app.Run(async ctx =>
            {
                string body;
                using (var streamReader = new System.IO.StreamReader(ctx.Request.Body, System.Text.Encoding.UTF8))
                {
                    body = await streamReader.ReadToEndAsync();
                }
                await ctx.Response.WriteAsync(body);
            });    
           //... 
        }
