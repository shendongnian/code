    public static Dictionary<string, T> LoadContent<T>(
        this ContentManager contentManager, string contentFolder)
    {
       var dir = new DirectoryInfo(contentManager.RootDirectory
           + "\\" + contentFolder);
       if (!dir.Exists)
          throw new DirectoryNotFoundException();
       var result = new Dictionary<string, T>();
       foreach (FileInfo file in dir.GetFiles("*.mp3"))
       {
          string key = Path.GetFileNameWithoutExtension(file.Name);
    
          result[key] = contentManager.Load<T>(
              contentManager.RootDirectory + "/" + contentFolder + "/" + key);
       }
       return result;
    }
