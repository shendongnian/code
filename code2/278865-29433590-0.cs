    public delegate int CallBackPtr(int hwnd, int param);
    [DllImport("coredll.dll")]
    [return: MarshalAs(UnmanagedType.I4)]
    private static extern int EnumWindows(IntPtr callPtr, int param);
    
    private static List<IntPtr> windows = new List<IntPtr>();
    
    private static int CallBackMethod(int hwnd, int param)
    {
        windows.Add(new IntPtr(hwnd));
        return 1;   
    }
    
    private static void GetAllWindowsHandles()
    {
       // using a delegate does NOT work.
       //EnumWindows(delegate(IntPtr wnd, IntPtr param)
       //{
       //    windows.Add(wnd);
       //    return true;
       //}, IntPtr.Zero);
    
       CallBackPtr callbackPtr = CallBackMethod;
       IntPtr cb = Marshal.GetFunctionPointerForDelegate(callbackPtr);
       EnumWindows(cb, 0);
    }
