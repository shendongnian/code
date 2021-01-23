    using Microsoft.Win32;
    RegistryKey registryBase = Registry.LocalMachine; // This would give you the standard Registry if you were using your own machine. Not needed for this example.
    registryBase = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64); // This will allow your 32 bit program to view the 64 bit registry.
    RegistryKey getKey = registryBase.OpenSubKey("HKLM\Software\Microsoft\Silverlight\Version", true); // Set to true or false to allow write permissions.
    getKey.SetValue("VersionKey", "0", RegistryValueKind.DWord); //Allow's you to edit the exact key type. Just change DWord etc...
