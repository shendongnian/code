    private const int RetrySetTopMostDelay = 200;
    private const int RetrySetTopMostMax = 20;
    // The code below will retry several times before giving up. This always worked with one retry in my tests.
    private static async Task RetrySetTopMost(IntPtr hwnd)
    {
        for (int i = 0; i < RetrySetTopMostMax; i++)
        { 
            await Task.Delay(RetrySetTopMostDelay);
            int winStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
            if ((winStyle & WS_EX_TOPMOST) != 0)
            {
                break;
            }
            App.Current.MainWindow.Topmost = false;
            App.Current.MainWindow.Topmost = true;
        }
    }
    internal const int GWL_EXSTYLE = -20;
    internal const int WS_EX_TOPMOST = 0x00000008;
    [DllImport("user32.dll")]
    internal static extern int GetWindowLong(IntPtr hwnd, int index);
