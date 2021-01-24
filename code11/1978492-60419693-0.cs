    [DllImport("user32.dll")]
    private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
    
    
    [... Code ...]
    
    
    Process process = new Process();
    process.StartInfo.FileName = pProcess;
    process.StartInfo.Arguments = pArgs;
    process.EnableRaisingEvents = true;
    process.Exited += new EventHandler((s, e) =>
    {
    	FermerOnglet(tabpage);
    });
    
    process.Start();
    while (process.MainWindowHandle == (IntPtr)0)
    {
    }
    SetParent(process.MainWindowHandle, metroPanel1.Handle);
