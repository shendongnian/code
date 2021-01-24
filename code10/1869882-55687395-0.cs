    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool IsIconic(IntPtr hWnd);
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool IsZoomed(IntPtr hWnd);
    enum WinState
    {
        None,
        Maximized,
        Minimized,
        Normal,
    }
    private static WinState GetWindowState(IntPtr hWnd)
    {
        WinState winState = WinState.None;
        if (hWnd != IntPtr.Zero)
        {
            if (IsIconic(hWnd))
            {
                winState = WinState.Minimized;
            }
            else if (IsZoomed(hWnd))
            {
                winState = WinState.Maximized;
            }
            else
            {
                winState = WinState.Normal;
            }
        }
        return winState;
    }
    private static WinState GetWindowState(string windowCaption)
    {
        return GetWindowState((IntPtr)FindWindow(null, windowCaption));
    }
