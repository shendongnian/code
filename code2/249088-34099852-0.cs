    private bool IsAlreadyRegistered()
    {
        using (var classesRootKey = Microsoft.Win32.RegistryKey.OpenBaseKey(
               Microsoft.Win32.RegistryHive.ClassesRoot, Microsoft.Win32.RegistryView.Default))
        {
            const string clsid = "{12345678-9012-3456-7890-123456789012}";
    
            var clsIdKey = classesRootKey.OpenSubKey(@"Wow6432Node\CLSID\" + clsid) ??
                            classesRootKey.OpenSubKey(@"CLSID\" + clsid);
    
            if (clsIdKey != null)
            {
                clsIdKey.Dispose();
                return true;
            }
    
            return false;
        }
    }
