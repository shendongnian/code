    using System.Runtime.InteropServices;
    [DllImport("user32.dll")]
    static extern IntPtr GetForegroundWindow();
    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, string lParam);
    [DllImport("user32.dll")]
    public static extern int PostMessage(IntPtr hWnd, int wMsg, int wParam, string lParam);
    // Windows message constants
    const int WM_SETTEXT = 0x000C;
    const int WM_KEYDOWN = 0x0100;
    // Virtual key codes
    const int VK_RETURN = 0x0D;
    const int VK_TAB = 0x09;
    public void DoLogin(string username, string password)
    {
        // Get handle for current active window
        IntPtr hWnd = GetForegroundWindow();
        // Send the username text to the active window
        SendMessage(hWnd, WM_SETTEXT, 0, username);
        // Send a TAB keystroke to go to the next field
        SendMessage(hWnd, WM_KEYDOWN, VK_TAB, null);
        // Send the password text
        SendMessage(hWnd, WM_SETTEXT, 0, password);
        // Send ENTER key to invoke login
        SendKeys.SendWait("{ENTER}");
        //--or--
        SendMessage(hWnd, WM_KEYDOWN, VK_RETURN, null);
        //--or--
        PostMessage(hWnd, WM_KEYDOWN, VK_RETURN, null);
    }
