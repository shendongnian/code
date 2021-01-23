    using System.Reflection.Assembly  
    using System.Diagnostics.FileVersionInfo
    // ...
    public string GetInformationalVersion(Assembly assembly) {
        return FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;
    }
