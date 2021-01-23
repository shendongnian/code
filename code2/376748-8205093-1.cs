    public class SomeClass : ISomeInterface
    {
     private MySettings settings = new Settings();
     public ISettings Settings
     {
      get { return (ISettings)settings; }
      set { settings = value as MySettings; }
     }
    }
    [Serializable]
    public class MySettings : ISettings
    {
     private DateTime dt;
     public MySettings() { dt = DateTime.Now; }
     public DateTime StartDate
     {
      get { return startFrom; }
      internal set { startFrom = value; }
     }
    }
