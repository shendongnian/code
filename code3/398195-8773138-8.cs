    string contentFolder = "Music";
    var dir = new DirectoryInfo(Content.RootDirectory + "\\" + contentFolder);
    if (!dir.Exists)
    {
        // Todo: Display a message to the user instead?
        throw new DirectoryNotFoundException();
    }
    string[] files = dir.GetFiles("*.mp3");
    for (int i = 0; i < files.Count(); ++i)
    {
        FileInfo file = files[i];
        string key = System.IO.Path.GetFileNameWithoutExtension(file.Name);
        var song = Content.Load<Song>(
            Content.RootDirectory + "/" + contentFolder + "/" + key);
        songsToPlay.Add(song);
    }
