      public class ResourceReader
      {
          private static ResourceManager _resourceManager = new ResourceManager(
               "Resources." + System.Reflection.Assembly
                   .GetExecutingAssembly()
                   .GetName()
                   .Version.ToString(),
               Assembly.GetExecutingAssembly());
    
          // If you have resource property btnID, you can expose it like this:
          public static string BtnID
          {
              get
              {
                  return _resourceManager.GetString("btnID");
              }
          }
          // you can add other properties for every value in the resource file.
      }
