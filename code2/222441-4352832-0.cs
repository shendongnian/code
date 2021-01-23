    static class FastFile
    {
        private const int MAX_PATH = 260;
        private const int MAX_ALTERNATE = 14;
    
        public static WIN32_FIND_DATA GetFileData(string fileName)
        {
            WIN32_FIND_DATA data;
            IntPtr handle = FindFirstFile(fileName, out data);
            if (handle == IntPtr.Zero)
                throw new IOException("FindFirstFile failed");
            FindClose(handle);
            return data;
        }
    
        [DllImport("kernel32")]
        private static extern IntPtr FindFirstFile(string fileName, out WIN32_FIND_DATA data);
        
        [DllImport("kernel32")]
        private static extern bool FindClose(IntPtr hFindFile);
    
    
        [StructLayout(LayoutKind.Sequential)]
        public struct FILETIME
        {
            public uint dwLowDateTime;
            public uint dwHighDateTime;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct WIN32_FIND_DATA
        {
            public FileAttributes dwFileAttributes;
            public FILETIME ftCreationTime;
            public FILETIME ftLastAccessTime;
            public FILETIME ftLastWriteTime;
            public int nFileSizeHigh;
            public int nFileSizeLow;
            public int dwReserved0;
            public int dwReserved1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string cFileName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ALTERNATE)]
            public string cAlternate;
        }
    }
