    using System.Runtime.InteropServices;
    [DllImport("user32.dll")]
    static extern IntPtr GetForegroundWindow();
    [DllImport("user32.dll")]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    [DllImport("user32.dll")]
    public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, string lParam);
    // Windows message constants
    const int WM_SETTEXT = 0x000C;
    public void DoLogin(string username, string password)
    {
        // Get handle for current active window
        IntPtr hWndMain = GetForegroundWindow();
        if (!hWndMain.Equals(IntPtr.Zero))
        {
            IntPtr hWnd;
            // Here you would need to find the username text input window
            if ((hWnd = FindWindowEx(hWndMain, IntPtr.Zero, "UserName", "")) != IntPtr.Zero)
                // Send the username text to the active window
			    SendMessage(hWnd, WM_SETTEXT, 0, username);
            // Here you would need to find the password text input window
            if ((hWnd = FindWindowEx(hWndMain, IntPtr.Zero, "Password", "")) != IntPtr.Zero)
    			// Send the password text
    			SendMessage(hWnd, WM_SETTEXT, 0, password);
			// Send ENTER key to invoke login
			SendKeys.SendWait("{ENTER}");
        }
    }
