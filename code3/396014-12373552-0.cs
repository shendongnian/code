    public class Win32ApiUtils
    {
        [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Unicode)]
        public struct SHFILEOPSTRUCT
        {
            public IntPtr hwnd;
            public FO_Func WFunc;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string PFrom;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pTO;
            public ushort fFlags;
            public bool FAnyOperationsAborted;
            public IntPtr HNameMappings;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string LpszProgressTitle;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct SHNAMEMAPPING
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string PszOldPath;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string PszNewPath;
            public int CchOldPath;
            public int CchNewPath;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct HANDLETOMAPPINGS
        {
            public uint UNumberOfMappings;
            public IntPtr LpSHNameMapping;
        }
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
        private static extern int SHFileOperation(ref SHFILEOPSTRUCT LpFileOp);
        [DllImport("Shell32.dll")]
        private static extern void SHFreeNameMappings(SHNAMEMAPPING IntPtr);
        public static int CopyFiles()
        {
            // set up our file operation structure
            SHFILEOPSTRUCT sh;
            sh.hwnd = IntPtr.Zero;
            sh.WFunc = FO_Func.FO_COPY;
            sh.PFrom = @"C:\temp\f1\a.txt" + Constants.vbNullChar + @"C:\temp\f1\b.txt" + Constants.vbNullChar +
                       Constants.vbNullChar;
            sh.fFlags = (ushort)FILEOP_FLAGS_ENUM.FOF_ALLOWUNDO
                        | (ushort)FILEOP_FLAGS_ENUM.FOF_MULTIDESTFILES
                        | (ushort)FILEOP_FLAGS_ENUM.FOF_WANTMAPPINGHANDLE;
            sh.FAnyOperationsAborted = false;
            sh.HNameMappings = IntPtr.Zero;
            sh.LpszProgressTitle = null;
            sh.pTO = @"C:\temp\a.txt" + Constants.vbNullChar + @"C:\temp\b.txt" + Constants.vbNullChar +
                     Constants.vbNullChar;
            
            int ret = SHFileOperation(ref sh);
            
            if (sh.HNameMappings != IntPtr.Zero)
            {
                // Copy from Sh.HNameMappings to HANDLETOMAPPINGS 
                HANDLETOMAPPINGS mappings =
                    (HANDLETOMAPPINGS)Marshal.PtrToStructure(sh.HNameMappings, typeof(HANDLETOMAPPINGS));
                // initialize the pointer for reading at the position of the mappings.LpSHNameMapping 
                IntPtr ptr = mappings.LpSHNameMapping;
                for (int I = 0; I < (int)mappings.UNumberOfMappings; I++)
                {
                    // read from the pointer
                    // copying to SHNAMEMAPPING
                    SHNAMEMAPPING mapping = (SHNAMEMAPPING)Marshal.PtrToStructure(ptr, typeof(SHNAMEMAPPING));
                    // create file info from mapping
                    // something we can get at
                    FileInfo fileNew = new FileInfo(mapping.PszNewPath);
                    Console.WriteLine("new file name: {0}", fileNew.Name);
                    // advance by the size of the structure to the next SHNAMEMAPPING
                    ptr = new IntPtr(ptr.ToInt32() + Marshal.SizeOf(typeof(SHNAMEMAPPING)));
                }
            }
            return ret;
        }
        [Flags]
        private enum FILEOP_FLAGS_ENUM : ushort
        {
            FOF_MULTIDESTFILES = 0x0001,
            FOF_CONFIRMMOUSE = 0x0002,
            FOF_SILENT = 0x0004, // don't create progress/report
            FOF_RENAMEONCOLLISION = 0x0008,
            FOF_NOCONFIRMATION = 0x0010, // Don't prompt the user.
            FOF_WANTMAPPINGHANDLE = 0x0020, // Fill in SHFILEOPSTRUCT.hNameMappings
            // Must be freed using SHFreeNameMappings
            FOF_ALLOWUNDO = 0x0040,
            FOF_FILESONLY = 0x0080, // on *.*, do only files
            FOF_SIMPLEPROGRESS = 0x0100, // means don't show names of files
            FOF_NOCONFIRMMKDIR = 0x0200, // don't confirm making any needed dirs
            FOF_NOERRORUI = 0x0400, // don't put up error UI
            FOF_NOCOPYSECURITYATTRIBS = 0x0800, // dont copy NT file Security Attributes
            FOF_NORECURSION = 0x1000, // don't recurse into directories.
            FOF_NO_CONNECTED_ELEMENTS = 0x2000, // don't operate on connected elements.
            FOF_WANTNUKEWARNING = 0x4000,
            // during delete operation, warn if nuking instead of recycling (partially overrides FOF_NOCONFIRMATION)
            FOF_NORECURSEREPARSE = 0x8000, // treat reparse points as objects, not containers
        }
        public enum FO_Func : uint
        {
            FO_MOVE = 0x0001,
            FO_COPY = 0x0002,
            FO_DELETE = 0x0003,
            FO_RENAME = 0x0004,
        }
    }
