    public static void InjectionPoint()
    {
        Thread thread = new Thread(new ThreadStart(DLLMessageLoop));
        thread.IsBackground = true;
        thread.Start();
    }
    public static void DLLMessageLoop()
    {
        _hookID = SetHook(_proc);
        Application.Run();
        UnhookWindowsHookEx(_hookID);
    }
