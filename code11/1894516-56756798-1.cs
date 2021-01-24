    public void Configuration(IAppBuilder app)
        {
            // Configure Web API for self-host.
            var config = new HttpConfiguration();
            WebApplication1.WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
