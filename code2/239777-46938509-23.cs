    string path = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
    RegistryKey rk = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, computer).OpenSubKey(path);
    string osName = rk.GetValue("productName").ToString();
    string servicePack = rk.GetValue("CSDVersion").ToString();
    byte[] digitalProductId = registry.GetValue("DigitalProductId") as byte[];
    string osProductKey = DecodeProductKey(digitalProductId);
