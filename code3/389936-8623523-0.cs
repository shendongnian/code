    #PRAGMA AUTORECOVER
    [dynamic, provider("RegProv"),
    ProviderClsid("{fe9af5c0-d3b6-11ce-a5b6-00aa00680c3f}"),   
    ClassContext("local|HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows
    \\CurrentVersion\\Uninstall")] 
    class InstalledSoftware 
    {
       [key] string KeyName;
       [read, propertycontext("DisplayName")]      string DisplayName;
       [read, propertycontext("DisplayVersion")]   string  DisplayVersion;
       [read, propertycontext("InstallDate")]      string InstallDate;
       [read, propertycontext("Publisher")]        string Publisher;
    };
