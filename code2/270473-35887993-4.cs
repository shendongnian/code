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
                    var Items = from mo in moc.Cast<ManagementObject>() select new { Path = (string)mo["ExecutablePath"] };
                    foreach (var Item in Items)
                    {
                        MethodResult = Item.Path;
                    }
                }
            }
        }
        catch //(Exception ex)
        {
            //ex.HandleException();
        }
        return MethodResult;
    }
