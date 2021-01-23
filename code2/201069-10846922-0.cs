    using System.Configuration;
    
    public static class AppSettingsGet
    {    
        public static string myKey
        {
            get { return ConfigurationManager.AppSettings["myKey"].ToString(); }
        }
    
        public static string imageFolder
        {
            get { return ConfigurationManager.AppSettings["imageFolder"].ToString(); }
        }
        
        // I also get my connection string from here
        public static string ConnectionString
        {
           get { return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; }
        }
    }
