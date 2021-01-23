      public static class CopyHelper
      {
        [Flags]
        public enum CopyFileFlags : uint
        {
            COPY_FILE_FAIL_IF_EXISTS          = 0x00000001,
            COPY_FILE_RESTARTABLE         = 0x00000002,
            COPY_FILE_OPEN_SOURCE_FOR_WRITE       = 0x00000004,
            COPY_FILE_ALLOW_DECRYPTED_DESTINATION = 0x00000008,
            COPY_FILE_COPY_SYMLINK        = 0x00000800 //NT 6.0+
        }
        public enum CopyProgressResult : uint
        {
            PROGRESS_CONTINUE = 0,
            PROGRESS_CANCEL   = 1,
            PROGRESS_STOP     = 2,
            PROGRESS_QUIET    = 3
        }
        public enum CopyProgressCallbackReason : uint
        {
            CALLBACK_CHUNK_FINISHED = 0x00000000,
            CALLBACK_STREAM_SWITCH  = 0x00000001
        }
    
        public delegate CopyProgressResult CopyProgressRoutine(
            long TotalFileSize,
            long TotalBytesTransferred,
            long StreamSize,
            long StreamBytesTransferred,
            uint dwStreamNumber,
            CopyProgressCallbackReason dwCallbackReason,
            IntPtr hSourceFile,
            IntPtr hDestinationFile,
            IntPtr lpData);
    
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]   
        [return: MarshalAs(UnmanagedType.Bool)]   
        public static extern bool CopyFileEx(string lpExistingFileName, 
            string lpNewFileName, CopyProgressRoutine lpProgressRoutine, 
            IntPtr lpData, ref bool pbCancel, CopyFileFlags dwCopyFlags);
      }
