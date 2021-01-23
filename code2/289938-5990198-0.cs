    if (!Ok)
    {
       System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcessesByName(ProductName);
       SetForegroundWindow(p[0].MainWindowHandle);
       ShowWindow(p[0].MainWindowHandle, SW_MAXIMIZE);
    }
