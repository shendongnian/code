    public interface IPlugin
    {
      public event EventHandler SomethingHappened;
      public void StartWatchingForSomething();
    }
    
    where the code would be something like...
    
    public static void Main()
    {
      foreach (var plugin in LoadAllPluginTypes()) // IoC container, MEF, something
      {
        plugin.SomethingHappened += SomethingHappenedEventHandler;
        plugin.StartWatchingForSomething();
      }
    
      public void SomethingHappenedEventHandler(object sender, EventArgs e)
      { 
        //derp
      }
    }
