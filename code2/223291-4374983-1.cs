    public static IEnumerable<string> GetMachingFiles(string pathA, string pathB)
    {
        var matchingFiles = new HashSet<string>();
    
        var allAfiles = Directory.GetFiles(pathA, "*", SearchOption.AllDirectories);
        foreach (var file in allAfiles)
        {
            foreach (var mathcFile in Directory.GetFiles(pathB, Path.GetFileName(file), SearchOption.AllDirectories))
                matchingFiles.Add(mathcFile);
        }
        return matchingFiles;
    }
