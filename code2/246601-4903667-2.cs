    static Dictionary<string, int> extensions = new Dictionary<string, int>();
    static void Main(string[] args)
    {
        recurseFolders(@"c:\");
        foreach (var extension in extensions)
            Console.WriteLine("{0}: {1} file(s)", extension.Key, extension.Value);
        Console.ReadLine();
    }
    private static void recurseFolders(string path)
    {
        string[] files= Directory.GetFiles(path,"*.*",SearchOption.TopDirectoryOnly);
        foreach (var extension in files.GroupBy(Path.GetExtension))
        {
            if(!extensions.ContainsKey(extension.Key))
                extensions.Add(extension.Key, extension.Count());
            else
                extensions[extension.Key] += extension.Count();
        }
        foreach (string directory in Directory.GetDirectories(path))
            recurseFolders(directory);
    }
