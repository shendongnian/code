    Microsoft.Owin.Hosting.WebApp.Start<StartupCustom>("http://localhost:8181/signalR");
    ...
    public class StartupOffline {
        public void Configuration(IAppBuilder app) {
            app.MapSignalR();
        }
    }
