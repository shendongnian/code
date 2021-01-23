    public static string GetProcessPath(int processId)
    {
        string MethodResult = "";
        try
        {
            string Query = "SELECT ExecutablePath FROM Win32_Process WHERE ProcessId = " + processId;
            using (ManagementObjectSearcher mos = new ManagementObjectSearcher(Query))
            {
                using (ManagementObjectCollection moc = mos.Get())
                {
                    string Path = (from mo in moc.Cast<ManagementObject>() select (string)mo["ExecutablePath"]).ToList<string>()[0];
                    MethodResult = Path;
                }
            }
        }
        catch (Exception ex)
        {
            ex.HandleException();
        }
        return MethodResult;
    }
