    public static IDictionary<string, IntPtr> GetOpenWindows()
    {
        IntPtr lShellWindow = GetShellWindow();
        Dictionary<string, IntPtr> lWindows = new Dictionary<string, IntPtr>();
        EnumWindows(delegate(IntPtr hWnd, int lParam)
        {
            if (hWnd == lShellWindow) return true;
            if (!IsWindowVisible(hWnd)) return true;
            int lLength = GetWindowTextLength(hWnd);
            if (lLength == 0) return true;
            StringBuilder lBuilder = new StringBuilder(lLength);
            GetWindowText(hWnd, lBuilder, lLength + 1);
            lWindows[lBuilder.ToString()] = hWnd;
            return true;
        }, 0);
        return lWindows;
    }
    public delegate bool EnumDelegate(IntPtr hWnd, int lParam);
    public delegate bool EnumedWindow(IntPtr handleWindow, ArrayList handles);
    [DllImport("USER32.DLL")]
    public static extern bool EnumWindows(EnumDelegate enumFunc, int lParam);
    [DllImport("USER32.DLL")]
    public static extern IntPtr GetShellWindow();
    [DllImport("USER32.DLL")]
    public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
    [DllImport("USER32.DLL")]
    public static extern int GetWindowTextLength(IntPtr hWnd);
    [DllImport("USER32.DLL")]
    public static extern bool IsWindowVisible(IntPtr hWnd);
    [DllImport("user32.dll")]
    public static extern bool SetForegroundWindow(IntPtr hWnd);
