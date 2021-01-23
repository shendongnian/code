    public static string GetRootProcessPath()
    {
        string MethodResult = "";
        try
        {
            string Query = "SELECT ExecutablePath FROM Win32_Process WHERE ProcessId = " + Process.GetCurrentProcess().Id;
            using (var searcher = new ManagementObjectSearcher(Query))
            {
                using (var results = searcher.Get())
                {
                    var query = from mo in results.Cast<ManagementObject>() select new { Path = (string)mo["ExecutablePath"] };
                    foreach (var item in query)
                    {
                        MethodResult = item.Path;
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
