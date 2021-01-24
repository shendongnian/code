    public static class Settings
    {
        public static string Database => ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        public static string Timeout => ConfigurationManager.AppSettings["timeout"];
    }
