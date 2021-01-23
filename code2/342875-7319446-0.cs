     namespace caLibServer
        {
            public class Settings
            {
                public virtual static string MyProperty1
                 //skip code
            }
        }
    
     namespace caLibClient
        {
            public class Settings : caLibServer.Settings
            {
                public static string MyProperty2
                 //skip code
            }
        }
