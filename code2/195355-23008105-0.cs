    private const int SW_SHOWNOACTIVATE = 4;
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern bool ShowWindow(System.IntPtr hWnd, int nCmdShow);
    public static void ShowInactiveTopmost(System.Windows.Forms.Form frm)
    {
        try
        {
             ShowWindow(frm.Handle, SW_SHOWNOACTIVATE);
        }
        catch (System.Exception ex)
        {
            // error handling
        }
    }
