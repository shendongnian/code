    public static event ValueEnterEventHandler CallEvent;
    public static void DispatchCompanyCall(string moduleName)
    {
        if (IsReady && CallEvent != null)
        CallEvent(null, new ValueEnterEventArgs(moduleName, false));
    }
