    [return: MarshalAs(UnmanagedType.Bool)]
    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
    
    private const UInt32 WM_KEYDOWN = 0x0100;
    private const UInt32 WM_KEYUP = 0x0101;
    
    public static void SendSelect(IntPtr HWnd)
    {
        PostMessage(HWnd, WM_KEYDOWN, KeyInterop.VirtualKeyFromKey(System.Windows.Input.Key.Enter), 0);
    }
