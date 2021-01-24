    public static void readDir(string currentDirectory)
    {
        string[] rootSub = Directory.GetDirectories(currentDirectory);
        string[] files = Directory.GetFiles(currentDirectory);
        Console.WriteLine(currentDirectory);
        Dictionary<string, int> extensions = new Dictionary<string, int>();
        foreach (var item in files)
        {
            string extension = Path.GetExtension(item).ToLower();
            if (!extensions.ContainsKey(extension))
            {
                extensions[extension] = 1;
            }
            else
            {
                extensions[extension]++;
            }
        }
        foreach (string key in extensions.Keys)
        {
            Console.WriteLine("{0} Files with Extension {1}", extensions[key], key);
        }
        Console.WriteLine();
        foreach (string dir in rootSub)
        {
            readDir(dir);
        }
    }
