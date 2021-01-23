    public class CredentialsConfigElement : System.Configuration.ConfigurationElement
        {
            [ConfigurationProperty("Username")]
            public string Username
            {
                get 
                {
                    return base["Username"] as string;
                }
            }
    
            [ConfigurationProperty("Password")]
            public string Password
            {
                get
                {
                    return base["Password"] as string;
                }
            }
        }
