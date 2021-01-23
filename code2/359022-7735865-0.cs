    public class Config
    {
        public static string QueriesPath
        {
            get
            {
                return ConfigurationManager.AppSettings["QueriesPath"].ToString();
            }
        }
    
        public static string SearchLogConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["SearchLog"].ConnectionString;
            }
        }
    }
