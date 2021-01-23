        public static FileStream WaitForFileAccess(string filePath, FileMode fileMode, FileAccess access, FileAccess share, TimeSpan timeout)
        {
            int errorCode;
            DateTime start = DateTime.Now;
            while (true)
            {
                SafeFileHandle fileHandle = CreateFile(filePath, ConvertFileAccess(access), ConvertFileShare(share), IntPtr.Zero,
                                                       ConvertFileMode(fileMode), EFileAttributes.Normal, IntPtr.Zero);
                if (!fileHandle.IsInvalid)
                {
                    return new FileStream(fileHandle, access);
                }
                errorCode = Marshal.GetLastWin32Error();
                if (errorCode != ERROR_SHARING_VIOLATION)
                {
                    break;
                }
                if ((DateTime.Now - start) > timeout)
                {
                    return null; // timeout isn't an exception
                }
                
                Thread.Sleep(100);
            }
            throw new IOException(new Win32Exception(errorCode).Message, errorCode);
        }
        private static EFileAccess ConvertFileAccess(FileAccess access)
        {
            return access == FileAccess.ReadWrite ? EFileAccess.GenericRead | EFileAccess.GenericWrite : access == FileAccess.Read ? EFileAccess.GenericRead : EFileAccess.GenericWrite;
        }
        private static EFileShare ConvertFileShare(FileAccess share)
        {
            return (EFileShare) ((uint) share);
        }
        private static ECreationDisposition ConvertFileMode(FileMode mode)
        {
            return mode == FileMode.Open ? ECreationDisposition.OpenExisting : mode == FileMode.OpenOrCreate ? ECreationDisposition.OpenAlways : (ECreationDisposition) (uint) mode;
        }
        
        [DllImport("kernel32.dll", EntryPoint = "CreateFileW", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern SafeFileHandle CreateFile(
           string lpFileName,
           EFileAccess dwDesiredAccess,
           EFileShare dwShareMode,
           IntPtr lpSecurityAttributes,
           ECreationDisposition dwCreationDisposition,
           EFileAttributes dwFlagsAndAttributes,
           IntPtr hTemplateFile);
