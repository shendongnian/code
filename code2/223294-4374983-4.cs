    public static IEnumerable<string> GetMachingFilesFast(string pathA, string pathB)
    {
        DirectoryInfo dirA = new DirectoryInfo(pathA);
        DirectoryInfo dirB = new DirectoryInfo(pathB);
    
        var filesA = dirA.GetFiles("*",SearchOption.AllDirectories);
        var filesB = dirB.GetFiles("*", SearchOption.AllDirectories);
    
        var matchingFiles = filesA.Where(fA => filesB.Any(fB => fA.Name == fB.Name))
                                  .Select(x => x.Name);
        return matchingFiles;
    }
