    else
    {
        foreach (Process process in processes)
        {
            if (process.Id != p.Id)
            {
                SwitchToThisWindow(process.MainWindowHandle, true);
                return;
            }
        }
    [System.Runtime.InteropServices.DllImport("user32.dll")] public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);
