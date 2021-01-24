    public class MyPlugin : IPlugin, IPostInitPlugin
    {
        public void Register(IAppHost appHost) {}
        public void AfterPluginsLoaded(IAppHost appHost)
        {
            appHost.GetContainer().AddSingleton<ICacheClient>(c => 
                new Engine(c.Resolve<IServerEvents>()));
        }
    }
