    public class YourService : ServiceBase
    {
      public static void Main(string[] args)
      {
        ServiceBase.Run(new ServiceBase[] { new YourService() });
      }
      protected overrides void OnStart(string[] args)
      {
        // Add code to start your logic here. Try to return immediately.
      }
    
      protected overrides void OnStop()
      {
        // Add code to stop your logic here.
      }
    }
