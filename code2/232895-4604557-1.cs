    [DllImport("user32.dll", EntryPoint = "SendMessage")]
    public static extern int SendMessageGetText(IntPtr hWnd, int msg, int wParam, StringBuilder lParam);
    
    const int WM_GETTEXT = 13;
    const int bufferSize = 1000; // adjust as necessary
    StringBuilder sb = new StringBuilder(bufferSize);
    SendMessageGetText(hWnd, WM_GETTEXT, bufferSize, sb);
    string controlText = sb.ToString();
