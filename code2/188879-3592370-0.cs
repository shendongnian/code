    public class BrowserModule : Module
    {
        private readonly string _executablePath;
        public BrowserModule(string executablePath)
        {
            _executablePath = executablePath;
        }
        public override void Load(ContainerBuilder builder)
        {
            builder
                .Register(c => new InternetExplorerBrowser(_executablePath))
                .As<IBrowser>()
                .InstancePerDependency();
        }
    }
