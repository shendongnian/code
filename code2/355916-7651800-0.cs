            private bool Recycle(string path)
        {
            try
            {
                ShowProgress(string.Format("Moving {0} to Recycle bin.", path));
                SHFILEOPSTRUCT sfo = new SHFILEOPSTRUCT();
                sfo.hwnd = IntPtr.Zero;
                sfo.wFunc = FO_DELETE;
                sfo.fFlags = FOF_ALLOWUNDO | FOF_NOCONFIRMATION;
                sfo.pFrom = path +'\0' + '\0';
                sfo.pTo = null;
                sfo.fAnyOperationsAborted = false;
                sfo.hNameMappings = IntPtr.Zero;
                sfo.lpszProgressTitle = string.Empty;
                int ret = SHFileOperation(ref sfo);
                return (ret == 0);
            }
            catch (Exception ex)
            {
                ShowProgress(string.Format("Failed to move {0} to Recycle bin.", path));
                ShowProgress(ex.ToString());
            }
            return false;
        }
        // SHFileOperation wFunc and wFunc values
        public const uint FO_MOVE = 0x0001;
        public const uint FO_COPY = 0x0002;
        public const uint FO_DELETE = 0x0003;
        public const uint FO_RENAME = 0x0004;
        public const ushort FOF_MULTIDESTFILES = 0x0001;
        public const ushort FOF_CONFIRMMOUSE = 0x0002;
        public const ushort FOF_SILENT = 0x0004; // don't create progress/report
        public const ushort FOF_RENAMEONCOLLISION = 0x0008;
        public const ushort FOF_NOCONFIRMATION = 0x0010; // Don't prompt the user.
        public const ushort FOF_WANTMAPPINGHANDLE = 0x0020;// Fill in SHFILEOPSTRUCT.hNameMappings
                                                        // Must be freed using SHFreeNameMappings
        public const ushort FOF_ALLOWUNDO = 0x0040;
        public const ushort FOF_FILESONLY = 0x0080;  // on *.*, do only files
        public const ushort FOF_SIMPLEPROGRESS = 0x0100;  // means don't show names of files
        public const ushort FOF_NOCONFIRMMKDIR = 0x0200;  // don't confirm making any needed dirs
        public const ushort FOF_NOERRORUI = 0x0400;  // don't put up error UI
        public const ushort FOF_NOCOPYSECURITYATTRIBS = 0x0800;  // dont copy NT file Security Attributes
        public const ushort FOF_NORECURSION = 0x1000;  // don't recurse ushorto directories.
        //[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
        //If you use the above you may encounter an invalid memory access exception (when using ANSI
        //or see nothing (when using unicode) when you use FOF_SIMPLEPROGRESS flag.
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct SHFILEOPSTRUCT
        {
            public IntPtr hwnd;
            public uint wFunc;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pFrom;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pTo;
            public ushort fFlags;
            [MarshalAs(UnmanagedType.Bool)]
            public bool fAnyOperationsAborted;
            public IntPtr hNameMappings;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszProgressTitle;
        }
        [DllImport("ceshell.dll")]
        public static extern int SHFileOperation([In] ref SHFILEOPSTRUCT lpFileOp);
