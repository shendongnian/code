    public class ExtractIcon
    {
        [DllImport("Shell32.dll")]
        private static extern int SHGetFileInfo(
            string pszPath, uint dwFileAttributes,
            out SHFILEINFO psfi, uint cbfileInfo,
            SHGFI uFlags);
        private struct SHFILEINFO
        {
            public SHFILEINFO(bool b)
            {
                hIcon = IntPtr.Zero; iIcon = 0; dwAttributes = 0; szDisplayName = ""; szTypeName = "";
            }
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            public string szDisplayName;
            public string szTypeName;
        };
        private enum SHGFI
        {
            SmallIcon = 0x00000001,
            OpenIcon = 0x00000002,
            LargeIcon = 0x00000000,
            Icon = 0x00000100,
            DisplayName = 0x00000200,
            Typename = 0x00000400,
            SysIconIndex = 0x00004000,
            LinkOverlay = 0x00008000,
            UseFileAttributes = 0x00000010
        }
        public static Icon GetIcon(string strPath, bool bSmall, bool bOpen)
        {
            SHFILEINFO info = new SHFILEINFO(true);
            int cbFileInfo = Marshal.SizeOf(info);
            SHGFI flags;
            if (bSmall)
                flags = SHGFI.Icon | SHGFI.SmallIcon;
            else
                flags = SHGFI.Icon | SHGFI.LargeIcon;
            if (bOpen) flags = flags | SHGFI.OpenIcon;
            SHGetFileInfo(strPath, 0, out info, (uint)cbFileInfo, flags);
            return Icon.FromHandle(info.hIcon);
        }
    }
