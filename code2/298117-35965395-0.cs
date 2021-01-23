    [DllImport("wininet.dll", SetLastError = true)]
            public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
            public const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
            public const int INTERNET_OPTION_REFRESH = 37;
    
     static void setProxyRegistry(string proxyhost, bool proxyEnabled, string username, string password)
            {
                const string userRoot = "HKEY_CURRENT_USER";
                const string subkey = "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
                const string keyName = userRoot + "\\" + subkey;
    
                Registry.SetValue(keyName, "ProxyServer", proxyhost, RegistryValueKind.String);
                Registry.SetValue(keyName, "ProxyEnable", proxyEnabled ? "1" : "0", RegistryValueKind.DWord);
    
                Registry.SetValue(keyName, "ProxyPass", password, RegistryValueKind.String);
                Registry.SetValue(keyName, "ProxyUser", username, RegistryValueKind.String);
    
                //<-loopback>;<local>
                Registry.SetValue(keyName, "ProxyOverride", "*.local", RegistryValueKind.String);
    
    
                // These lines implement the Interface in the beginning of program 
                // They cause the OS to refresh the settings, causing IP to realy update
                InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
                InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);
            }
