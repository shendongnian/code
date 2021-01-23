    public interface IMyPluginHost
    {
      public int RegisterPlugin(int FunctionalityGroup, object WorkerBee, int MinSDKVersion, int MaxSDKVersion);
      ... //Whatever you need to allow the plugin to call into the app
    }
    
    public interface IMyPlugin
    {
      public int InitPlugin(IMyPluginHost myhost); //Return value is hust an error code
      ... //Whatever you need to allow the app to call into the plugin
    }
