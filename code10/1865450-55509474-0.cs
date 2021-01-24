    public void ConfigureAuth(IAppBuilder app)
    {
        app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        
        // creates owin contexts and stuff
    }
 
