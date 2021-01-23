    public class ConfigurationSettings
    {
    
        public static string MyConnectionString
        {
    	get
                if(ConfigurationSettings.TestMode)
                    return Properties.Settings.Default.MyConnectionStringTest;
                else
                    return Properties.Settings.Default.MyConnectionStringProd;
    	}
        }
        
        // I typically only have test and not-test. This could
        // easily be some other combination of values to satisfy
        // multiple environments.
        public static bool TestMode { get; private set;}
    }
