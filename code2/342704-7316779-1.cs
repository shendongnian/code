    static public String FullContentDirectory(this ContentManager content)
    {
        var appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
        return System.IO.Path.Combine(appPath, content.RootDirectory);
    }
