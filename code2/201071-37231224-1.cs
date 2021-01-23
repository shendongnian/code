    using System; 
    using System.Configuration;
    namespace Configuration
    {
       public static class SiteConfigurationReader
       {
          public static String appKeyString  //for string type value
          {
             get
             {
                return ConfigurationManager.AppSettings.Get("appKeyString");
             }
          }
          public static Int32 appKeyInt  //to get integer value
          {
             get
             {
                return ConfigurationManager.AppSettings.Get("appKeyInt").ToInteger(true);
             }
          }
          // you can also get the app setting by passing the key
          public static Int32 GetAppSettingsInteger(string keyName)
          {
              try
              {
                return Convert.ToInt32(ConfigurationManager.AppSettings.Get(keyName));
            }
            catch
            {
                return 0;
            }
          }
       }
    }
