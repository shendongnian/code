var nameOfTheFile = "test.pdf";
ResourceManager.GetResourceInfo(nameOfTheFile);
if (ResourceManager.resourceExists == false)
{ Console.WriteLine("Specified PDF file not found"); return; }
Console.WriteLine("Resouce found in DLL");
ResourceManager.LoadResource(nameOfTheFile);//Will load the pdf in your main project
Process.Start(nameOfTheFile);
   
<!>
 class ResourceManager
 {
        public static bool resourceExists { get; set; } = false;
        private static Stream resourceStream { get; set; }
        public static void GetResourceInfo(string fileNameWithExtension)
        {
            const string pathToResource = "AssistantLib.Resources.Guidelines";
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
       
  [1]: https://i.stack.imgur.com/M3DIh.png
