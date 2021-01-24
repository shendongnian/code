    using Microsoft.AspNet.SignalR;
    using Microsoft.Owin;
    using System.Net;
    [assembly: OwinStartup(typeof(YourProject.Startup))]
    
    
    namespace YourProject
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
    			var hubConfiguration = new HubConfiguration
                {
                    EnableDetailedErrors = true
                };
                app.MapSignalR(hubConfiguration);
            }
        }
    }
