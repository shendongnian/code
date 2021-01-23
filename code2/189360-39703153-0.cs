    public void enforceAdminPrivilegesWorkaround()
    {
        RegistryKey rk;
        string registryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon\";
        try
        {
            if(Environment.Is64BitOperatingSystem)
            {
                rk = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            }
            else
            {
                rk = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32);
            }
            rk = rk.OpenSubKey(registryPath, true);
        }
        catch(System.Security.SecurityException ex)
        {
            MessageBox.Show("Please run as administrator");
            System.Environment.Exit(1);
        }
        catch(Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }
