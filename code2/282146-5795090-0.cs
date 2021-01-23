    using System.Runtime.InteropServices;
    [DllImport("user32.dll")]
    private static extern int GetSystemMetrics(int nIndex);
    // System metric constant for Windows XP Tablet PC Edition
    private const int SM_TABLETPC = 86;
    private readonly bool tabletEnabled;
    
    protected bool IsRunningOnTablet()
    {
        return (GetSystemMetrics(SM_TABLETPC) != 0);
    }
