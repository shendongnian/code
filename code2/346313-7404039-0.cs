    public static class ExtensionMethods
    {
       public static string ToClientDate(this DateTime dt)
       {
          string configFormat = System.Configuration.ConfigurationManager.AppSettings["DateFormat"];
          return dt.ToString(configFormat);
       }
    }
