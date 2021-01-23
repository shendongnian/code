    internal class DataAccess
    {
       static string GetDatabaseConnection()
        {
          return ConfigurationManager.ConnectionStrings["AppDb"].ConnectionString;
          // where AppDb is defined in your web.config/app.config.
        }
    }
