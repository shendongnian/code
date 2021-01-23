    public static List<string> DirSearch(string startDirectory, IEnumerable<string> extensions)
    {
        Stack<string> directoryStack = new Stack<string>();
        List<string> files = new List<string>();
        directoryStack.Push(startDirectory);
        while (directoryStack.Count > 0)
        {
            string currentDirectory = directoryStack.Pop();
            DirectoryInfo di = new DirectoryInfo(currentDirectory);
            files.AddRange(di.EnumerateFiles()
                             .Where(f => extensions.Contains(f.Extension))
                             .Select(f => f.FullName));
            foreach (string directory in Directory.GetDirectories(currentDirectory))
                directoryStack.Push(directory);
        }
        return files;
    }
