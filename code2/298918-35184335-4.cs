    namespace MyConfig
    {
        public class AppConfigurationSettings
        {
            public AppConfigurationSettings()
            {
                /* initialize the object if you want to output a new document
                 * for use as a template or default settings possibly when 
                 * an app is started.
                 */
                if (AppSettings == null) { AppSettings=new AppSettings();}
            }
    
            public AppSettings AppSettings { get; set; }
        }
    
        public class AppSettings
        {
            public bool DebugMode { get; set; } = false;
        }
    }
