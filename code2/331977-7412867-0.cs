    [System.Runtime.InteropServices.DllImport("user32.dll")]
    static extern IntPtr GetForegroundWindow();
    
    private static bool IsActive(Window wnd)
    {
    	// workaround for minimization bug
    	// Managed .IsActive may return wrong value
    	if (wnd == null) return false;
    	return GetForegroundWindow() == new WindowInteropHelper(wnd).Handle;
    }
    public static bool IsApplicationActive()
    {
    	foreach (var wnd in Application.Current.Windows.OfType<Window>())
    		if (IsActive(wnd)) return true;
    	return false;
    }
