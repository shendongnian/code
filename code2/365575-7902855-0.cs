    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool ReleaseCapture();
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
    internal const uint WM_NCLBUTTONDOWN = 0xA1;
    internal const int HTCAPTION = 2; // Window captions
    internal const int HTBOTTOMRIGHT = 17; // Bottom right corner
    /// <summary>
    /// Simulates a Windows drag on the window border or title.
    /// </summary>
    /// <param name="handle">The window handle to drag.</param>
    /// <param name="dragType">A HT* constant to determine which part to drag.</param>
    internal static void DragWindow(IntPtr handle, int dragType) {
        User32.ReleaseCapture();
        User32.PostMessage(handle, User32.WM_NCLBUTTONDOWN, new IntPtr(dragType), IntPtr.Zero);
    }
