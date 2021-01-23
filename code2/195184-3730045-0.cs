    public static bool IsComPlusApplicationRunning(string appName)
    {
        uint appCount;
        IntPtr appDataPtr = IntPtr.Zero;
        COMSVCSLib.IGetAppData getAppData = null;
    
        COMSVCSLib.TrackerServer tracker = new COMSVCSLib.TrackerServerClass();
    
        try
        {        
            getAppData = (COMSVCSLib.IGetAppData)tracker;
    
            unsafe
            {            
                getAppData.GetApps(out appCount, new IntPtr(&appDataPtr));
            }
    
            int appDataSize = Marshal.SizeOf(typeof(COMSVCSLib.appData));
    
            for (int appIndex = 0; appIndex < appCount; appIndex++)
            {
                COMSVCSLib.appData appData = (COMSVCSLib.appData)Marshal.PtrToStructure(
                    new IntPtr(appDataPtr.ToInt32() + (appIndex * appDataSize)),
                    typeof(COMSVCSLib.appData));
    
                string currentAppName = GetPackageNameByPID(appData.m_dwAppProcessId);
    
                if (string.Compare(currentAppName, appName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    Console.WriteLine("Application " + appName + " is running with PID " + appData.m_dwAppProcessId);
                    return true;
                }
            }
        }
        finally
        {
            if (tracker != null)
            {
                Marshal.ReleaseComObject(tracker);
            }
        }
        return false;
    }
    
    private static string GetPackageNameByPID(uint PID)
    {
        COMSVCSLib.MtsGrp grpObj = new COMSVCSLib.MtsGrpClass();
    
        try
        {
            object obj = null;
            COMSVCSLib.COMEvents eventObj = null;
    
            for (int i = 0; i < grpObj.Count; i++)
            {
                try
                {
                    grpObj.Item(i, out obj);
    
                    eventObj = (COMSVCSLib.COMEvents)obj;
    
                    if (eventObj.GetProcessID() == PID)
                    {
                        return eventObj.PackageName;
                    }
                }
                finally
                {
                    if (obj != null)
                    {
                        Marshal.ReleaseComObject(obj);
                    }
                }
            }
        }
        finally
        {
            if (grpObj != null)
            {
                Marshal.ReleaseComObject(grpObj);
            }
        }
    
        return null;
    }
