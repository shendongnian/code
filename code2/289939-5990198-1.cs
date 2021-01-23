    [DllImport("user32.dll", CharSet = CharSet.Auto)
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool IsIconic(IntPtr hWnd);
    
    // [...]
    if (!Ok)
    {
       System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcessesByName(ProductName);
       IntPtr hwndMain= p[0].MainWindowHandle;
       SetForegroundWindow(hwndMain);
       if (IsIconic(hwndMain))
       {
          ShowWindow(hwndMain, SW_MAXIMIZE);
       }
    }
