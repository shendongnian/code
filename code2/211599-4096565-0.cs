     string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
        string computerName = System.Environment.MachineName;
        using (Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey))
        {
                        var query = from a in key.GetSubKeyNames()
                                    let r = key.OpenSubKey(a)
                                    select new
                                    {
                                        Application = r.GetValue("DisplayName"),
                                        AppVersion = r.GetValue("DisplayVersion")
                                    };
        }
