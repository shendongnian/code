    private static IntPtr _hookId = IntPtr.Zero;
    private readonly External.LowLevelKeyboardProc _proc;
    
    public FrmMain()
    {
        _proc = HookCallback;
        _hookId = SetHook(_proc);
        InitializeComponent();
    }
    
    private static IntPtr SetHook(External.LowLevelKeyboardProc proc)
    {
        using(var curProcess = Process.GetCurrentProcess())
        {
            using(var curModule = curProcess.MainModule)
            {
                return External.SetWindowsHookEx(External.WH_KEYBOARD_LL, proc, External.GetModuleHandle(curModule.ModuleName), 0);
            }
        }
    }
    
    private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        // You can change this to WM_KEYDOWN
        if (nCode >= 0 && wParam == (IntPtr)External.WM_KEYUP)
        {
             // Code you want to run when a button is pressed.
        }
        return External.CallNextHookEx(_hookId, nCode, wParam, lParam);
    }
