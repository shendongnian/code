        public class VM : ConfigurationSection
        {
         
            public static VM GetSection(string section)
            {
                return ConfigurationManager.GetSection(section) as VM;
            }  
    
            [ConfigurationProperty("namespace", IsRequired = true)]
            public string Namespace
            {
                get
                {                
                    return (string)base["namespace"];
                }
            }
            [ConfigurationProperty("assembly", IsRequired = true)]
            public string Assembly
            {
                get
                {
                    return (string)base["assembly"];
                }
            }        
        }
