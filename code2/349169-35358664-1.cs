    public class DALCommon
    {
        public static string GetConnectionString
        {
            //return System.Configuration.ConfigurationManager.AppSettings["connectionInfo"];
            get
            {
                NameValueCollection appSettings = ConfigurationManager.AppSettings;
                string server = appSettings["server"];
                string userid = appSettings["userid"];
                string password = appSettings["password"];
                return String.Format("server={0};user id={1}; password={2}; database=dbmystock; pooling=false", server, userid, password);
            }
        }
    }
