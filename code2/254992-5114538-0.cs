    [DllImport("dwmapi.dll", PreserveSig = false)]
    public static extern bool DwmIsCompositionEnabled();
    
    // Check to see if composition is Enabled
    if (DwmIsCompositionEnabled())
    {
        // enable glass rendering
    }
    else
    {
        // fallback rendering
    }
