    using Microsoft.Win32;
    //...
    static string GetCOMPath(string comName)
    {
        RegistryKey comKey = Registry.ClassesRoot.OpenSubKey(comName + "\\CLSID");
        string clsid = (string)comKey.GetValue("");
        comKey = Registry.ClassesRoot.OpenSubKey("CLSID\\" + clsid + "\\LocalServer32");
        return (string)comKey.GetValue("");
    }
