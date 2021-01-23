    static void Main()
    {
        IEnumerable<string> files = GetFiles("*.log", @"C:\", @"D:\", @"E:\");
    }
    static IEnumerable<string> GetFiles(string searchPattern, params string[] directories)
    {
        foreach (string directory in directories)
        {
            foreach (string file in Directory.GetFiles(directory, searchPattern))
                yield return file;
        }
    }
