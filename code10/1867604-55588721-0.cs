    List<string> AllFiles = new List<string>();
    void ParsePath(string path)
    {
        string[] SubDirs = Directory.GetDirectories(path);
        AllFiles.AddRange(SubDirs);
        AllFiles.AddRange(Directory.GetFiles(path));
        foreach (string subdir in SubDirs)
            ParsePath(subdir);
    }
