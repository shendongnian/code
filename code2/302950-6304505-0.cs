        static string GetProductId()
        {
            RegistryKey windowsNTKey = null;
            RegistryKey localMachine = null;
            if (Environment.Is64BitOperatingSystem)
            {
                localMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            }
            else
            {
                localMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32);
            }
            windowsNTKey = localMachine.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion");
            return windowsNTKey.GetValue("ProductId").ToString();
        }
