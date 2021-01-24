        class ResourceManager
        {
          public static bool resourceExists { get; set; } = false;
          private static Stream resourceStream { get; set; }
          public static void GetResourceInfo(string fileNameWithExtension)
          {
            //Substitut this with your Project Name
            //Class Library Name AssistantLib >  Resources > AssistantLib.dll 
            const string pathToResource = "AssistantLib.Resources.Guidelines";
            //The Dll that you want to Load
            var assembly = Assembly.Load("AssistantLib");
            //var names = assembly.GetManifestResourceNames();
            var stream = assembly.GetManifestResourceStream($"{pathToResource}.{fileNameWithExtension}");
            if (stream == null)
                return;
    
            resourceExists = true;
    
            resourceStream = stream;
    
           }
    
          public static void LoadResource(string newFileNameWithExtension)
          {
            if(File.Exists(newFileNameWithExtension))
            {
                Console.WriteLine("File already exists");
                return;
            }
            using (Stream s = File.Create(newFileNameWithExtension))
            {
                Console.WriteLine("Loading file");
                resourceStream.CopyTo(s);
            }
          }
        }
