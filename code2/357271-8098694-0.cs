    RegistryKey rk = Registry.LocalMachine;
    RegistryKey rk1 = rk.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\SystemRestore");
    string sysRestore = rk1.GetValue("RPSessionInterval").ToString();
    if (sysRestore.Contains("1"))
    {
        MessageBox.Show("System Restore is Enabled");
    }
    
    if (sysRestore.Contains("0"))
    {
        MessageBox.Show("System Restore is Disabled");
    }
