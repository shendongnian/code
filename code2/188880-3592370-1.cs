    public class ConfiguredBrowserModule : Module
    {
        public override void Load(ContainerBuilder builder)
        {
            var executablePath = ConfigurationManager.AppSettings["ExecutablePath"];
            builder.RegisterModule(new BrowserModule(executablePath));
        }
    }
