    [DllImport("dwmapi.dll", PreserveSig = false)]
    public static extern bool DwmIsCompositionEnabled();
    
    // Check to see if composition is Enabled
    if (Environment.OSVersion.Version.Major >= 6 && DwmIsCompositionEnabled())
    {
        // enable glass rendering
    }
    else
    {
        // fallback rendering
    }
