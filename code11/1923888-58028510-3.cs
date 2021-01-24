    Microsoft.Owin.Hosting.WebApp.Start<StartupCustom>("http://localhost:8181/signalR");
    ...
    public class StartupCustom{
        public void Configuration(IAppBuilder app) {
            app.MapSignalR();
        }
    }
