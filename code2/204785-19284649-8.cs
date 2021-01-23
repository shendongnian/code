    public class ServerInfoConfigElement : ConfigurationElement
        {
            [ConfigurationProperty("Address")]
            public string Address
            {
                get
                {
                    return base["Address"] as string;
                }
            }
    
            [ConfigurationProperty("Port")]
            public int? Port
            {
                get
                {
                    return base["Port"] as int?;
                }
            }
        }
