    [Flags]
    internal enum SHGFI : uint
    {
        ADDOVERLAYS = 0x20,
        ATTR_SPECIFIED = 0x20000,
        ATTRIBUTES = 0x800,
        DISPLAYNAME = 0x200,
        EXETYPE = 0x2000,
        ICON = 0x100,
        ICONLOCATION = 0x1000,
        LARGEICON = 0,
        LINKOVERLAY = 0x8000,
        OPENICON = 2,
        OVERLAYINDEX = 0x40,
        PIDL = 8,
        SELECTED = 0x10000,
        SHELLICONSIZE = 4,
        SMALLICON = 1,
        SYSICONINDEX = 0x4000,
        TYPENAME = 0x400,
        USEFILEATTRIBUTES = 0x10
    }
    
    /// <summary>
    /// This structure contains information about a file object.
    /// </summary>
    /// <remarks>
    /// This structure is used with the SHGetFileInfo function.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal struct SHFILEINFO
    {
        /// <summary>
        /// Handle to the icon that represents the file. 
        /// </summary>
        internal IntPtr hIcon;
    
        /// <summary>
        /// Index of the icon image within the system image list.
        /// </summary>
        internal int iIcon;
    
        /// <summary>
        /// Specifies the attributes of the file object.
        /// </summary>
        internal SFGAO dwAttributes;
    
        /// <summary>
        /// Null-terminated string that contains the name of the file as it 
        /// appears in the Windows shell, or the path and name of the file that
        /// contains the icon representing the file.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.MAX_PATH)]
        internal string szDisplayName;
    
        /// <summary>
        /// Null-terminated string that describes the type of file. 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        internal string szTypeName;        
    }
    
    /// <summary>
    /// Specifies the executable file type.
    /// </summary>
    public enum ExecutableType : int
    {
        /// <summary>
        /// The file executable type is not able to be determined.
        /// </summary>
        Unknown = 0,
    
        /// <summary>
        /// The file is an MS-DOS .exe, .com, or .bat file.
        /// </summary>
        DOS,
    
        /// <summary>
        /// The file is a Microsoft Win32®-based console application.
        /// </summary>
        Win32Console,
    
        /// <summary>
        /// The file is a Windows application.
        /// </summary>
        Windows,        
    }
    
    // Retrieves information about an object in the file system,
    // such as a file, a folder, a directory, or a drive root.
    [DllImport("shell32",
        EntryPoint = "SHGetFileInfo",
        ExactSpelling = false,
        CharSet = CharSet.Auto,
        SetLastError = true)]
    internal static extern IntPtr SHGetFileInfo(
        string pszPath,
        FileAttributes dwFileAttributes,
        ref SHFILEINFO sfi,
        int cbFileInfo,
        SHGFI uFlags);
    
    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    private ExecutableType IsExecutable(string fileName)
    {
        if (fileName == null)
        {
            throw new ArgumentNullException("fileName");
        }
    
        ExecutableType executableType = ExecutableType.Unknown;
    
        if (File.Exists(fileName)
        {
            // Try to fill the same SHFILEINFO struct for the exe type. The returned pointer contains the encoded 
            // executable type data.
            ptr = IntPtr.Zero;
            ptr = SHGetFileInfo(fileName, FileAttributes.Normal, ref this.shellFileInfo, Marshal.SizeOf(typeof(SHFILEINFO)), SHGFI.EXETYPE);
    
            // We need to split the returned pointer up into the high and low order words. These are important
            // because they help distinguish some of the types. The possible values are:
            //
            // Value                                            Meaning
            // ----------------------------------------------------------------------------------------------
            // 0                                                Nonexecutable file or an error condition. 
            // LOWORD = NE or PE and HIWORD = Windows version   Microsoft Windows application.
            // LOWORD = MZ and HIWORD = 0                       Windows 95, Windows 98: Microsoft MS-DOS .exe, .com, or .bat file
            //                                                  Microsoft Windows NT, Windows 2000, Windows XP: MS-DOS .exe or .com file 
            // LOWORD = PE and HIWORD = 0                       Windows 95, Windows 98: Microsoft Win32 console application 
            //                                                  Windows NT, Windows 2000, Windows XP: Win32 console application or .bat file 
            // MZ = 0x5A4D - DOS signature.
            // NE = 0x454E - OS/2 signature.
            // LE = 0x454C - OS/2 LE or VXD signature.
            // PE = 0x4550 - Win32/NT signature.
    
            int wparam = ptr.ToInt32();
            int loWord = wparam & 0xffff;
            int hiWord = wparam >> 16;
    
            if (wparam == 0)
            {
                executableType = ExecutableType.Unknown;
            }
            else
            {
                if (hiWord == 0x0000)
                {
                    if (loWord == 0x5A4D)
                    {
                        // The file is an MS-DOS .exe, .com, or .bat
                        executableType = ExecutableType.DOS;
                    }
                    else if (loWord == 0x4550)
                    {
                        executableType = ExecutableType.Win32Console;
                    }
                }
                else
                {
                    if (loWord == 0x454E || loWord == 0x4550)
                    {
                        executableType = ExecutableType.Windows;
                    }
                    else if (loWord == 0x454C)
                    {
                        executableType = ExecutableType.Windows;
                    }
                }
            }
        }
        
        return executableType;
    } 
