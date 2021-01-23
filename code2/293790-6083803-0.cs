    [DllImport("user32.dll")]
    public static extern int FindWindow(string lpClassName, string lpWindowName);
     
    [DllImport("user32.dll")]
    public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);
    
    public const int WM_COMMAND = 0x0112;
    public const int WM_CLOSE = 0xF060;
    
    int handle = FindWindow(lpClassName, lpWindowName);
    SendMessage(handle, WM_COMMAND, WM_CLOSE, 0);
