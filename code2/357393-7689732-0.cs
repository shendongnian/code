    public static class DefaultSupportValues
    {
        public static string ProjectID
        {
            get
            {
                return ConfigurationManager.AppSettings["DefaultProjectId"];
            }
        }
    }
