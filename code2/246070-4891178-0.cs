    using System;
    using System.Runtime.InteropServices;
    
    namespace CompareByPath    
    {    
      public static class DirectoryHelper  
      {
        // all user defined types copied from 
        // http://pinvoke.net/default.aspx/kernel32.CreateFile
        // http://pinvoke.net/default.aspx/kernel32.GetFileInformationByHandle
        // http://pinvoke.net/default.aspx/kernel32.CloseHandle
    
        public const short INVALID_HANDLE_VALUE = -1;
     
        struct BY_HANDLE_FILE_INFORMATION
        {
          public uint FileAttributes;
          public System.Runtime.InteropServices.ComTypes.FILETIME CreationTime;
          public System.Runtime.InteropServices.ComTypes.FILETIME LastAccessTime;
          public System.Runtime.InteropServices.ComTypes.FILETIME LastWriteTime;
          public uint VolumeSerialNumber;
          public uint FileSizeHigh;
          public uint FileSizeLow;
          public uint NumberOfLinks;
          public uint FileIndexHigh;
          public uint FileIndexLow;
        }
        
        [Flags]
        public enum EFileAccess : uint
        {
          GenericRead = 0x80000000,
          GenericWrite = 0x40000000,
          GenericExecute = 0x20000000,
          GenericAll = 0x10000000
        }
        
        [Flags]
        public enum EFileShare : uint
        {
          None = 0x00000000,
          Read = 0x00000001,
          Write = 0x00000002,
          Delete = 0x00000004
        }
       
        [Flags]
        public enum EFileAttributes : uint
        {
          Readonly = 0x00000001,
          Hidden = 0x00000002,
          System = 0x00000004,
          Directory = 0x00000010,
          Archive = 0x00000020,
          Device = 0x00000040,
          Normal = 0x00000080,
          Temporary = 0x00000100,
          SparseFile = 0x00000200,
          ReparsePoint = 0x00000400,
          Compressed = 0x00000800,
          Offline = 0x00001000,
          NotContentIndexed = 0x00002000,
          Encrypted = 0x00004000,
          Write_Through = 0x80000000,
          Overlapped = 0x40000000,
          NoBuffering = 0x20000000,
          RandomAccess = 0x10000000,
          SequentialScan = 0x08000000,
          DeleteOnClose = 0x04000000,
          BackupSemantics = 0x02000000,
          PosixSemantics = 0x01000000,
          OpenReparsePoint = 0x00200000,
          OpenNoRecall = 0x00100000,
          FirstPipeInstance = 0x00080000
        }
    
        public enum ECreationDisposition : uint
        {
          New = 1,
          CreateAlways = 2,
          OpenExisting = 3,
          OpenAlways = 4,
          TruncateExisting = 5
        }
          
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool GetFileInformationByHandle(IntPtr hFile, out        BY_HANDLE_FILE_INFORMATION lpFileInformation);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern IntPtr CreateFile(String lpFileName, UInt32 dwDesiredAccess, UInt32 dwShareMode, IntPtr lpSecurityAttributes, UInt32 dwCreationDisposition, UInt32 dwFlagsAndAttributes, IntPtr hTemplateFile);
    
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);
    
        public static bool CompareDirectories(string d1, string d2)
        {
          bool result = false;
     
          BY_HANDLE_FILE_INFORMATION info1;
          BY_HANDLE_FILE_INFORMATION info2;
     
          IntPtr fileHandle1 = CreateFile(d1, (uint)EFileAccess.GenericRead, (uint)EFileShare.Read, IntPtr.Zero, (uint)ECreationDisposition.OpenExisting, (uint)(EFileAttributes.Directory | EFileAttributes.BackupSemantics), IntPtr.Zero);
          if (fileHandle1.ToInt32() != INVALID_HANDLE_VALUE)
          {
            bool rc = GetFileInformationByHandle(fileHandle1, out info1);
            if ( rc )
            {
              IntPtr fileHandle2 = CreateFile(d2, (uint)EFileAccess.GenericRead, (uint)EFileShare.Read, IntPtr.Zero, (uint)ECreationDisposition.OpenExisting, (uint)(EFileAttributes.Directory | EFileAttributes.BackupSemantics), IntPtr.Zero);
              if (fileHandle2.ToInt32() != INVALID_HANDLE_VALUE)
              {
                rc = GetFileInformationByHandle(fileHandle2, out info2);
                if ( rc )
                {
                  if (( info1.FileIndexHigh == info2.FileIndexHigh) &&
                      ( info1.FileIndexLow == info2.FileIndexLow) &&
                      ( info1.VolumeSerialNumber == info2.VolumeSerialNumber))
                  {
                    result = true;
                  }
                }
              }
     
              CloseHandle(fileHandle2);
            }
          }
    
          CloseHandle(fileHandle1);
    
          return result;
        }
      }
    }
