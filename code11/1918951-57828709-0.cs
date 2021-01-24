    namespace MyApp.Hubs {
        public class MyHub : Hub {
            readonly IApplicationLifetime appLifetime;
            static Dictionary<int, VBLightSession> activeUsers = new Dictionary<int, VBLightSession>();
            public MyHub(IApplicationLifetime appLifetime) {
                this.appLifetime = appLifetime;
            }
        }
    }
