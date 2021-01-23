    public static void Main(string[] args)
    {
        if (InitdeDEDll()) // Create dll if it's missing.
        {
            // Restart the application if the language-package was added
            Application.Restart();
            return;
        }
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new YOURMAINFORM());
    }
    private static bool InitdeDEDll() // Initialize the German de-DE DLL
    {
        try
        {
            // Language of my package. This will be the name of the subfolder.
            string language = "de-DE";
            return TryCreateFileFromRessource(language, @"NAMEOFYOURDLL.dll",
                NAMESPACEOFYOURRESSOURCE.NAMEOFYOURDLLINRESSOURCEFILE);
        }
        catch (Exception)
        {
            return false;
        }
    }
    private static bool TryCreateFileFromRessource(string subfolder, string fileName, byte[] buffer)
    {
        try
        {
            // path of the subfolder
            string subfolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + (subfolder != "" ? @"\" : "") + subfolder;
            // Create subfolder if it doesn't exist
            if (!Directory.Exists(subfolder))
                Directory.CreateDirectory(subfolderPath);
            
            fileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\" + subfolder + (subfolder!=""?@"\":"") + fileName;
            if (!File.Exists(fileName)) // if the dll doesn't already exist, it has to be created
            {
                // Write dll
                Stream stream = File.Create(fileName);
                stream.Write(buffer, 0, buffer.GetLength(0));
                stream.Close();
            }
            else
            {
                return false;
            }
        }
        catch
        {
            return false;
        }
        return true;
    }
