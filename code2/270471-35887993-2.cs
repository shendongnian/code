    public static string GetRootProcessPath()
    {
        string MethodResult = "";
        try
        {
            string Query = "SELECT ExecutablePath FROM Win32_Process WHERE ProcessId = " + Process.GetCurrentProcess().Id;
            using (ManagementObjectSearcher mos = new ManagementObjectSearcher(Query))
            {
                using (ManagementObjectCollection results = mos.Get())
                {
                    var Items = from mo in results.Cast<ManagementObject>() select new { Path = (string)mo["ExecutablePath"] };
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
