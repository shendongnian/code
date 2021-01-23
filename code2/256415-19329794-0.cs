    using System.Runtime.InteropServices;
    ...
    public const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;
    public const uint SHGFI_DISPLAYNAME = 0x000000200;     // get display name
    [DllImport("shell32")]
    public static extern int SHGetFileInfo(string pszPath, uint dwFileAttributes, 
        out SHFILEINFO psfi, uint cbFileInfo, uint flags);
    [StructLayout(LayoutKind.Sequential)]
    public struct SHFILEINFO
    {
        public IntPtr hIcon;
        public IntPtr iIcon;
        public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    };
    public  static string GetDisplayName(string path)
    {
        SHFILEINFO shfi = new SHFILEINFO();
        if (0 != SHGetFileInfo(path,FILE_ATTRIBUTE_NORMAL,out shfi,
            (uint)Marshal.SizeOf(typeof(SHFILEINFO)),SHGFI_DISPLAYNAME))
        {
            return shfi.szDisplayName;
        }
        return null;
    }
