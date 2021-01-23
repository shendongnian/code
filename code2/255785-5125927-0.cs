    public delegate bool CallBackPtr(int hwnd, int lParam);
    
    
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool EnumWindows(CallBackPtr lpEnumFunc, UInt32 lParam);
    
    
    static bool callbackreport(int hwnd, int lparam)
    {
        Console.WriteLine("{0} {1}", hwnd, lparam);
        return true;
    }
    
    static void Main(string[] args)
    {
        EnumWindows(Program.callbackreport,0);
    }
