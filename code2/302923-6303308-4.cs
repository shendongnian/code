    const long HWND_TOPMOST = -1;
    const long SWP_NOMOVE = 2;
    const long SWP_NOSIZE = 1;
    
    [DllImport("user32.dll")]
    private static extern long SetWindowPos(long hwnd, long hWndInsertAfter, long X, long Y, long cx, long cy, long wFlags);
    
    private void Form_Load() {
        SetWindowPos(Form1.hwnd, HWND_TOPMOST, 0, 0, 0, 0, (SWP_NOMOVE | SWP_NOSIZE));
    }
    
    [DllImport("user32.dll")]
    private static extern long SetParent(long hWndChild, long hWndNewParent);
    
    [DllImport("user32.dll")]
    private static extern long GetForegroundWindow();
    
    private void Timer1_Timer() {
        long mhwnd;
        mhwnd = GetForegroundWindow;
        SetParent;
        Form1.hwnd;
        mhwnd;
    }
