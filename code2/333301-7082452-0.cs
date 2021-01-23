    static long GetDirectorySize(string path)
    {
        string[] files = Directory.GetFiles(path, "*.*");
        long size = 0;
        foreach (string name in files)
        {
            FileInfo info = new FileInfo(name);
            size += info.Length;
        }
        return size;
    }
