    public class FtpSettingsSection : ConfigurationSection
    {
        public FtpSettingsSection() 
        {
            // force it to double load.
            if (this.Host.ElementInformation.IsPresent) ;
        }
        [ConfigurationProperty("host", IsRequired = true)]
        public HostElement Host
        {
            get { return (HostElement)this["host"]; }
            set { this["host"] = value; }
        }
    }
