    (in the code for a Form)
    [DllImport("dwmapi.dll", PreserveSig = false)]
    public static extern bool DwmIsCompositionEnabled();
    // When Aero is enabled, and our FormBorderStyle is FixedToolWindow,
    //    Windows will lie to us about our size and position.
    public bool AeroIsMessingWithUs()
    {
        bool ret = false;
        // check for other Fixed styles here if needed
        if (FormBorderStyle == System.Windows.Forms.FormBorderStyle.FixedToolWindow)
        {
            if (Environment.OSVersion.Version.Major >= 6 && DwmIsCompositionEnabled())
            {
                // Aero is enabled
                ret = true;
            }
        }
        return ret;
    }
    public int MyWindowHeight()
    {
        int height = Height;
        if (AeroIsMessingWithUs())
        {
            // there are actually 5 more pixels on the top and bottom
            height += 10;
        }
        return height;
    }
    public int MyWindowWidth()
    {
        int width = Width;
        if (AeroIsMessingWithUs())
        {
            // there are 5 more pixels on the left and right
            width += 10;
        }
        return width;
    }
