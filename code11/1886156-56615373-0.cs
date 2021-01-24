    string[] recentFiles = System.IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.History), "*", SearchOption.AllDirectories);
    
    foreach (var file in recentFiles)
    {
       System.IO.File.Delete(file);
    }
