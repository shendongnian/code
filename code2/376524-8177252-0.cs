    public static class Config
    {
       public static string ConnectionString
       {
          get
          {
             return WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
          }
       }
    }
