    enum PCUserStatuses {
        Locked, // all users are locked
        LoggedOff, // No users are logged in
        InUse, // A user is using this computer
        Unknown // unable to connect to computer / other error
    }
    
    PCUserStatuses GetPCUserStatus(string machineName) {
        try {
            var scope = GetManagementScope(machineName);
            scope.Connect();
    
            var explorerProcesses = Process.GetProcessesByName("explorer", machineName)
                                        .Select(p => p.Id.ToString())
                                        .ToHashSet();
    
            var REprocessid = new Regex(@"(?<=Handle="").*?(?="")", RegexOptions.Compiled);
    
            var numberOfLogonSessionsWithExplorer = new ManagementObjectSearcher(scope, new SelectQuery("SELECT * FROM Win32_SessionProcess")).Get()
                                                        .Cast<ManagementObject>()
                                                        .Where(mo => explorerProcesses.Contains(REprocessid.Match(mo["Dependent"].ToString()).Value))
                                                        .Select(mo => mo["Antecedent"].ToString())
                                                        .Distinct()
                                                        .Count();
    
            var numberOfUserDesktops = new ManagementObjectSearcher(scope, new SelectQuery("select * from win32_Perfrawdata_TermService_TerminalServicesSession")).Get().Count - 1; // don't count Service desktop
            var numberOflogonUIProcesses = Process.GetProcessesByName("LogonUI", machineName).Length;
    
            if (numberOflogonUIProcesses >= numberOfUserDesktops) {
                if (numberOfLogonSessionsWithExplorer > 0)
                    return PCUserStatuses.Locked;
                else
                    return PCUserStatuses.LoggedOff;
            }
            else
                return PCUserStatuses.InUse;
        }
        catch {
            return PCUserStatuses.Unknown;
        }
    }
     
