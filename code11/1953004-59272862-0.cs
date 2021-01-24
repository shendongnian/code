    public static IApplicationBuilder Configure(this IApplicationBuilder app)
            {
                app.UseHsts();
                app.UseHttpsRedirection(); 
                app.UseRouting();
                // more...
    
                return app;
            }
