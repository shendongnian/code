    public static string GetExeDirSubPath(string subPath)
    {
        return new DirectoryInfo( Path.Combine( GetExeDirPath(), subPath ) ).FullName; // DI stripts dtuff  like "..\..\" and moves to the actual path
    }
    
    public static string GetExeDirPath()
    {
        System.Reflection.Assembly a = System.Reflection.Assembly.GetEntryAssembly();
        string baseDir = System.IO.Path.GetDirectoryName(a.Location);
        return baseDir;
    }
