    using Shell32;
    
    private Shell32.Folder GetShell32Folder(string folderPath)
    {
        Type shellAppType = Type.GetTypeFromProgID("Shell.Application");
        Object shell = Activator.CreateInstance(shellAppType);
        return (Shell32.Folder)shellAppType.InvokeMember("NameSpace",
        System.Reflection.BindingFlags.InvokeMethod, null, shell, new object[] { folderPath });
    }
