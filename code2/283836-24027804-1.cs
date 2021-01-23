    //This will disable "Download signed ActiveX controls" computer policy for Internet Zone (zone #3)
    const string keyPath = @"SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\3";
    var gpo = new LocalPolicy.ComputerGroupPolicyObject();
    using (var machine = gpo.GetRootRegistryKey(LocalPolicy.GroupPolicySection.Machine))
    {
        using (var terminalServicesKey = machine.CreateSubKey(keyPath))
        {
            terminalServicesKey.SetValue("1001", 3, Microsoft.Win32.RegistryValueKind.DWord);
        }
    }
    gpo.Save();
