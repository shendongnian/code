    using (var root = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
    {
        using (var key = root.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion", false))
        {
            var registeredOwner = key.GetValue("RegisteredOwner");
        }
    }
