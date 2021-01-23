    [Export(typeof(IPlugin))]
    public class MyPlugin : IPlugin
    {
        private readonly IConfig config;
    
        [ImportingConstructor]
        public MyPlugin(IConfig config)
        {
            if (config == null)
                throw new ArgumentNullException("config");
            this.config = config;
        }
    }
