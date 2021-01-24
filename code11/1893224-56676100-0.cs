    public class Startup {
        public void Configuration(IAppBuilder app) {
            var config = new System.Web.Http.HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config); //<-- THIS WAS MISSING 
        }
    }
