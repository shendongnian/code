    private static IList<string> GetFilesToDepth(string path, int depth)
    {
        var files = Directory.EnumerateFiles(path).ToList();
        if (depth > 0)
        {
            var folders = Directory.EnumerateDirectories(path);
            foreach (var folder in folders)
            {                    
                files.AddRange(GetFiles(folder, depth - 1));
            }
        }
        return files;
    }
