        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            configureOAuth(app);
            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
