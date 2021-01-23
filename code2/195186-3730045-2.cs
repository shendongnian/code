    public static bool IsComPlusApplicationRunning(string appName)
    {
        int appDataSize = Marshal.SizeOf(typeof(COMSVCSLib.appData));
        Type appDataType = typeof(COMSVCSLib.appData);
    
        uint appCount;
        IntPtr appDataPtr = IntPtr.Zero;    
        
        GCHandle gh = GCHandle.Alloc(appDataPtr, GCHandleType.Pinned);
        IntPtr addressOfAppDataPtr = gh.AddrOfPinnedObject();
        
        COMSVCSLib.IGetAppData getAppData = null;
        COMSVCSLib.TrackerServer tracker = null;
        
        try
        {
            tracker = new COMSVCSLib.TrackerServerClass();
            getAppData = (COMSVCSLib.IGetAppData)tracker;
    
            getAppData.GetApps(out appCount, addressOfAppDataPtr);
            appDataPtr = new IntPtr(Marshal.ReadInt32(addressOfAppDataPtr));
    
            for (int appIndex = 0; appIndex < appCount; appIndex++)
            {
                COMSVCSLib.appData appData = (COMSVCSLib.appData)Marshal.PtrToStructure(
                    new IntPtr(appDataPtr.ToInt32() + (appIndex * appDataSize)),
                    appDataType);
    
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
            Marshal.FreeCoTaskMem(appDataPtr);
    
            if (tracker != null)
            {
                Marshal.ReleaseComObject(tracker);
            }
    
            gh.Free();
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
