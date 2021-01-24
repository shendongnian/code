    using System.Xml.Serialization;
    [Serializable]
    public class AppSettings
    {
      // The singleton
      static public AppSettings Instance { get; private set;  }
      static public string Filename { get; set; }
      static AppSettings()
      {
        Instance = new AppSettings();
      }
      // The persistence
      static public void Load()
      {
        if ( !File.Exists(Filename) )
          return;
        using ( FileStream fs = new FileStream(Filename, FileMode.Open, FileAccess.Read) )
          Instance = (AppSettings)new XmlSerializer(typeof(AppSettings)).Deserialize(fs);
      }
      static public void Save()
      {
        using ( FileStream fs = new FileStream(Filename, FileMode.Create, FileAccess.Write) )
          new XmlSerializer(Instance.GetType()).Serialize(fs, Instance);
      }
      // The settings
      public bool IsFisrtStartup { get; set; } = true;
      public string ExportPath { get; set; }
    }
