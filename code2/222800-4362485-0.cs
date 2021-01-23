    public enum SystemIcons
    {
        Application = 32512,
        Error = 32513,
        Hand = Error,
        Question = 32514,
        Warning = 32515,
        Exclamation = Warning,
        Information = 32516,
        Asterisk = Information,
        WinLogo = 32517,
        Shield = 32518,
    }
    
    public static ImageSource LoadSystemIcon(SystemIcons iconId)
    {
        string iconName = "#" + ((int)iconId);
        IntPtr hIcon = LoadIcon(IntPtr.Zero, iconName);
        if (hIcon == IntPtr.Zero)
            return null;
    
        return System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
            hIcon, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
    }
    
    [DllImport("user32.dll")]
    static extern IntPtr LoadIcon(IntPtr hInstance, string lpIconName);
