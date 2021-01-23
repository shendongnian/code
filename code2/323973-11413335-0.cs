    System.Reflection.Assembly entryAssembly = 
        System.Reflection.Assembly.GetEntryAssembly();
    string applicationPath = entryAssembly != null ? entryAssembly.Location :
        System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
    string applicationDirectory = Path.GetDirectoryName(applicationPath);
