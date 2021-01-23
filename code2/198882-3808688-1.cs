    public static System.IO.Stream WaitForExclusiveFileAccess(string filePath, int timeout)
    {
        IntPtr fHandle;
        int errorCode;
        DateTime start = DateTime.Now;
        while(true)
        {
            fHandle = CreateFile(filePath, EFileAccess.GenericRead | EFileAccess.GenericWrite, EFileShare.None, IntPtr.Zero,
                                 ECreationDisposition.OpenExisting, EFileAttributes.Normal, IntPtr.Zero);
            if (fHandle != IntPtr.Zero && fHandle.ToInt64() != -1L)
                return new System.IO.FileStream(fHandle, System.IO.FileAccess.ReadWrite, true);
            errorCode = Marshal.GetLastWin32Error();
            if (errorCode != ERROR_SHARING_VIOLATION)
                break;
            if (timeout >= 0 && (DateTime.Now - start).TotalMilliseconds > timeout)
                break;
            System.Threading.Thread.Sleep(100);
        }
        
        throw new System.IO.IOException(new System.ComponentModel.Win32Exception(errorCode).Message, errorCode);
    }
    #region Win32
    const int ERROR_SHARING_VIOLATION = 32;
    [Flags]
    enum EFileAccess : uint
    {
        GenericRead = 0x80000000,
        GenericWrite = 0x40000000
    }
    [Flags]
    enum EFileShare : uint
    {
        None = 0x00000000,
    }
    enum ECreationDisposition : uint
    {
        OpenExisting = 3,
    }
    [Flags]
    enum EFileAttributes : uint
    {
        Normal = 0x00000080,
    }
    [DllImport("kernel32.dll", EntryPoint = "CreateFileW", SetLastError = true, CharSet = CharSet.Unicode)]
    static extern IntPtr CreateFile(
       string lpFileName,
       EFileAccess dwDesiredAccess,
       EFileShare dwShareMode,
       IntPtr lpSecurityAttributes,
       ECreationDisposition dwCreationDisposition,
       EFileAttributes dwFlagsAndAttributes,
       IntPtr hTemplateFile);
    #endregion
