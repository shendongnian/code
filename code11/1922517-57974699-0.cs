    using System.Configuration;
    
    public static string UserName
            {
                get { return ConfigurationManager.AppSettings["UserName"]; }
                set { ConfigurationManager.AppSettings["UserName"] = value; }
            }
