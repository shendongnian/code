    public class BrowserSection : ConfigurationSection
    {
        [ConfigurationProperty("executablePath")]
        public string ExecutablePath
        {
            get { return (string) this["executablePath"]; }
            set { this["executablePath"] = value; }
        }
    }
    public class ConfiguredBrowserModule : Module
    {
        public override void Load(ContainerBuilder builder)
        {
            var section = (BrowserSection) ConfigurationManager.GetSection("myApp.browser");
            if(section == null)
            {
                section = new BrowserSection();
            }
            builder.RegisterModule(new BrowserModule(section.ExecutablePath));
        }
    }
