    static void Main(string[] args)
    {
        const string path = @"C:\temp\";
        DoOnSubfolders(path);
    }
    
    private static void DoOnSubfolders(string rootPath)
    {
        DirectoryInfo d = new DirectoryInfo(rootPath);
        FileInfo[] fis = d.GetFiles();
        foreach (var fi in fis)
        {
            string str = File.ReadAllText(fi.FullName);
            //do your stuff
        }
    
        DirectoryInfo[] ds = d.GetDirectories();
        foreach (var info in ds)
        {
            DoOnSubfolders(info.FullName);
        }
    }
