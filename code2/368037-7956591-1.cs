    public class FirstProjectClass 
    {
      public static int SyncEveryMinutes
      {
          get { return (int)ConfigurationManager.AppSetting["SyncEveryMinutes"] };
      }
    }
    
    
    public class SecondProjectClass
    {
      public void ShowConfigedValue()
      {
          Console.Writeline("Syncing every {0} minutes", FirstProjectClass.SyncEveryMinutes);
      }
    }
