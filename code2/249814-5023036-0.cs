    const int WM_THEMECHANGED = 0x031A;
    const int WM_DWMCOMPOSITIONCHANGED = 0x031E;
    private static void ApplyTheme(IntPtr hwnd)
    {
        if (DwmIsCompositionEnabled())
        {
            HwndSource.FromHwnd(hwnd).CompositionTarget.BackgroundColor = Colors.Transparent;
            MARGINS margins = new MARGINS(new Thickness(-1));
            DwmExtendFrameIntoClientArea(hwnd, ref margins);
        }
        else
        {
            HwndSource.FromHwnd(hwnd).CompositionTarget.BackgroundColor = SystemColors.ActiveCaptionBrush.Color;
        }
    }
    private static IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    {
        if (msg == WM_THEMECHANGED)
        {
            ApplyTheme(hwnd);
        }
        if (msg == WM_DWMCOMPOSITIONCHANGED)
        {
            ApplyTheme(hwnd);
        }
        return IntPtr.Zero;
    }
