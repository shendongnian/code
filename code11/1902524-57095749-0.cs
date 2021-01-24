    public void Configuration(IAppBuilder app)
    {
        ...
        var config = new HttpConfiguration();
        config.MapHttpAttributeRoutes();
        app.UseWebApi(config);
        ...
     }
