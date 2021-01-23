    static void ChangeServicePath(string svcName, string exePath)
    {
        const int SERVICE_NO_CHANGE = -1;
        using (ServiceController control = new ServiceController(svcName))
            ChangeServiceConfig(control.ServiceHandle,
                                SERVICE_NO_CHANGE,
                                SERVICE_NO_CHANGE,
                                SERVICE_NO_CHANGE,
                                exePath,
                                null,
                                IntPtr.Zero,
                                null,
                                null,
                                null,
                                null);
    }
