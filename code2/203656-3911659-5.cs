    String directoryName = "C:\\Consolidated";
    DirectoryInfo dirInfo = new DirectoryInfo(directoryName);
    if (dirInfo.Exists == false)
        Directory.CreateDirectory(directoryName);
    List<String> MyMusicFiles = Directory
                       .GetFiles("C:\\Music", "*.*", SearchOption.AllDirectories).ToList();
    foreach (string file in MyMusicFiles)
    {
        FileInfo mFile = new FileInfo(file);
        // to remove name collisions
        if (new FileInfo(dirInfo + "\\" + mFile.Name).Exists == false) 
        {
             mFile.MoveTo(dirInfo + "\\" + mFile.Name);
        }
    }
