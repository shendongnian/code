    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR<WebPortalConnection>("/socket");
        }
    }
    public class WebPortalConnection : PersistentConnection
    {
        // Methods here
    }
