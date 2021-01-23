    public class CustomApplicationConfigSection : System.Configuration.ConfigurationSection
        {
            private static readonly ILog log = LogManager.GetLogger(typeof(CustomApplicationConfigSection));
            public const string SECTION_NAME = "CustomApplicationConfig";
    
            [ConfigurationProperty("Credentials")]
            public CredentialsConfigElement Credentials
            {
                get
                {
                    return base["Credentials"] as CredentialsConfigElement;
                }
            }
    
            [ConfigurationProperty("PrimaryAgent")]
            public ServerInfoConfigElement PrimaryAgent
            {
                get
                {
                    return base["PrimaryAgent"] as ServerInfoConfigElement;
                }
            }
    
            [ConfigurationProperty("SecondaryAgent")]
            public ServerInfoConfigElement SecondaryAgent
            {
                get
                {
                    return base["SecondaryAgent"] as ServerInfoConfigElement;
                }
            }
    
            [ConfigurationProperty("Site")]
            public SiteConfigElement Site
            {
                get
                {
                    return base["Site"] as SiteConfigElement;
                }
            }
    
            [ConfigurationProperty("Lanes")]
            public LaneConfigCollection Lanes
            {
                get { return base["Lanes"] as LaneConfigCollection; }
            }
        }
