    [DllImport("dwmapi.dll", PreserveSig = false)]
    public static extern bool DwmIsCompositionEnabled();
    
    // Check to see if composition is Enabled
    if (DwmIsCompositionEnabled() && Environment.OSVersion.Version.Major >= 6)
    {
        // enable glass rendering
    }
    else
    {
        // fallback rendering
    }
