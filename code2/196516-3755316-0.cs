    string target = "yourFilenameToMatch";
    string current = Directory.GetCurrentDirectory();
    
    // 1. check subtree from current directory
    matches=Directory.GetFiles(current, target, SearchOption.AllDirectories);
    if (matches.Length>0)
        return matches[0];
    
    // 2. check system path
    string systemPath = Environment.GetEnvironmentVariable("SYSTEMROOT");
    char[] split = new char[] {";"};
    foreach (string nextDir in systemPath.Split(split))
    {
        if (File.Exists(nextDir + '\\' + target)
        {
            return nextDir;
        }
    }
    
    return String.Empty;
