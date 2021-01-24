    app.UseSpa(spa =>
    {
        spa.ApplicationBuilder.MapWhen(
            (context)=>!context.User.Identity.IsAuthenticated, 
            ab => {
                ab.Run(async (ctx )=> {
                    ctx.Response.StatusCode = 401;
                    //redirect to login page
                    ctx.Response.Headers.Add("Location", "....");
                    //await ctx.Response.WriteAsync("Authecation Failed");
                });
            }
        );
        spa.Options.SourcePath = "ClientApp";
        if (env.IsDevelopment())
        {
            spa.UseReactDevelopmentServer(npmScript: "start");
        }
    });
 
