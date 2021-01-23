        public  static string GetDisplayName(Environment.SpecialFolder specialFolder)
        {
            IntPtr pidl = IntPtr.Zero;
            try
            {
                HResult hr = SHGetFolderLocation(IntPtr.Zero, (int) specialFolder, IntPtr.Zero, 0, out pidl);
                if (hr.IsFailure)
                    return null;
                SHFILEINFO shfi;
                if (0 != SHGetFileInfo(
                            pidl,
                            FILE_ATTRIBUTE_NORMAL,
                            out shfi,
                            (uint)Marshal.SizeOf(typeof(SHFILEINFO)),
                            SHGFI_PIDL | SHGFI_DISPLAYNAME))
                {
                    return shfi.szDisplayName;
                }
                return null;
            }
            finally
            {
                if (pidl != IntPtr.Zero)
                    ILFree(pidl);
            }
        }
        public static string GetDisplayName(string path)
        {
            SHFILEINFO shfi;
            if (0 != SHGetFileInfo(
                        path,
                        FILE_ATTRIBUTE_NORMAL,
                        out shfi,
                        (uint)Marshal.SizeOf(typeof(SHFILEINFO)),
                        SHGFI_DISPLAYNAME))
            {
                return shfi.szDisplayName;
            }
            return null;
        }
        private const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;
        private const uint SHGFI_DISPLAYNAME = 0x000000200;     // get display name
        private const uint SHGFI_PIDL = 0x000000008;     // pszPath is a pidl
        [DllImport("shell32")]
        private static extern int SHGetFileInfo(IntPtr pidl, uint dwFileAttributes, out SHFILEINFO psfi, uint cbFileInfo, uint flags);
        [DllImport("shell32")]
        private static extern HResult SHGetFolderLocation(IntPtr hwnd, int nFolder, IntPtr token, int dwReserved, out IntPtr pidl);
        [DllImport("shell32")]
        private static extern void ILFree(IntPtr pidl);
        [StructLayout(LayoutKind.Sequential)]
        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }
    [StructLayout(LayoutKind.Sequential)]
    public struct HResult
    {
        private int _value;
        public int Value
        {
            get { return _value; }
        }
        public Exception Exception
        {
            get { return Marshal.GetExceptionForHR(_value); }
        }
        public bool IsSuccess
        {
            get { return _value >= 0; }
        }
        public bool IsFailure
        {
            get { return _value < 0; }
        }
    }
