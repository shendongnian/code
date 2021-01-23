    using System.Reflection;
    using System.Diagnostics;
    Assembly assembly = Assembly.GetExecutingAssembly();
    FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
    string version = fileVersionInfo.ProductVersion;
