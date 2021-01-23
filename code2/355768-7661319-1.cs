    public static bool SetMachineName(string newName)
    {
        RegistryKey key = Registry.LocalMachine;
        string activeComputerName = "SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ActiveComputerName";
        RegistryKey activeCmpName = key.CreateSubKey(activeComputerName);
        activeCmpName.SetValue("ComputerName", newName);
        activeCmpName.Close();
        string computerName = "SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ComputerName";
        RegistryKey cmpName = key.CreateSubKey(computerName);
        cmpName.SetValue("ComputerName", newName);
        cmpName.Close();
        string _hostName = "SYSTEM\\CurrentControlSet\\services\\Tcpip\\Parameters\\";
        RegistryKey hostName = key.CreateSubKey(_hostName);
        hostName.SetValue("Hostname",newName);
        hostName.SetValue("NV Hostname",newName);
        hostName.Close();
        return true;
    }
