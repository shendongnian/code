    var dir = new DirectoryInfo(contentManager.RootDirectory + "\\" + contentFolder);
    if (!dir.Exists)
        throw new DirectoryNotFoundException();
    string[] files = dir.GetFiles("*.mp3");
    for (int i = 0; i < files.Count(); ++i)
    {
        FileInfo file = files[i];
        string key = System.IO.Path.GetFileNameWithoutExtension(file.Name);
        songsToPlay.Add(contentManager.Load<Song>(
            contentManager.RootDirectory + "/" + contentFolder + "/" + key));
    }
