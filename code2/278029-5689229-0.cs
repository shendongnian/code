    namespace Service
    {
      class Program
      {
        static void Main(string[] args)
        {
          string[] splitSettings = { "SettingsLib.Settings", "EncodeAudio", "False" };
          SetProperty(splitSettings[0], splitSettings[1], splitSettings[2]);  
        }
    
        static void SetProperty(string typeName, string propertyName, object value)
        {
          var type = Type.GetType(typeName);
          if (type == null) 
          {
            throw new ArgumentException("Unable to get type", "typeName");
          }
    
          var pi = type.GetProperty(propertyName);
          if (pi == null) 
          {
            throw new ArgumentException("Unable to find property on type", "propertyName");
          }
    
          object propertyValue = value;
    
          if (propertyValue != null)
          {
            // You might need more elaborate testing here to ensure that you can handle 
            // all the various types, you might need to special case some types here 
            // but this will work for the basics.
            if (pi.PropertyType != propertyValue.GetType())
            {
              propertyValue = Convert.ChangeType(propertyValue, pi.PropertyType);
            }
          }
    
          pi.SetValue(null, propertyValue, null);
        }
      }
    }
    
    namespace SettingsLib
    {
      public static class Settings
      {
        public static bool EncodeAudio { get; set; }    
      }
    }
