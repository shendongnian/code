    [DllImport("user32.dll")]
    static extern bool SetForegroundWindow(IntPtr hWnd);
    public static void activateMediaCenterForm()
    {
        System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcessesByName("ehshell");
        if (p.Length > 0) //found
        {
            SetForegroundWindow(p[0].MainWindowHandle);
        }
        //else not Found -> Do nothing.
    }
