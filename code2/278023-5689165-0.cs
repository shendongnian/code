    namespace SettingsLib
    {
      public static class Settings
      {
        public static bool EncodeAudio { get; set; }
      }
    }
    namespace Service
    {
       void SetSettings()
       {
         string[] splitSettings = { "SettingsLib.Settings", "EncodeAudio", "False" };
         dynamic property = Assembly.GetExecutingAssembly().GetTypes()
               .First(a => a.FullName == splitSettings[0]).GetProperty(splitSettings[1]);
         property = splitSettings[2];
       }
    }
