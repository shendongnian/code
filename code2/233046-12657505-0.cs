    using System;
    using System.Text;
    using System.Runtime.InteropServices;
    using Microsoft.Win32.SafeHandles;
    using System.ComponentModel;
    
    internal static class NativeMethods
    {
        [Flags]
        public enum EFileAccess : uint
        {
            //
            // Standard Section
            //
    
            AccessSystemSecurity = 0x1000000,   // AccessSystemAcl access type
            MaximumAllowed = 0x2000000,     // MaximumAllowed access type
    
            Delete = 0x10000,
            ReadControl = 0x20000,
            WriteDAC = 0x40000,
            WriteOwner = 0x80000,
            Synchronize = 0x100000,
    
            StandardRightsRequired = 0xF0000,
            StandardRightsRead = ReadControl,
            StandardRightsWrite = ReadControl,
            StandardRightsExecute = ReadControl,
            StandardRightsAll = 0x1F0000,
            SpecificRightsAll = 0xFFFF,
    
            FILE_READ_DATA = 0x0001,        // file & pipe
            FILE_LIST_DIRECTORY = 0x0001,       // directory
            FILE_WRITE_DATA = 0x0002,       // file & pipe
            FILE_ADD_FILE = 0x0002,         // directory
            FILE_APPEND_DATA = 0x0004,      // file
            FILE_ADD_SUBDIRECTORY = 0x0004,     // directory
            FILE_CREATE_PIPE_INSTANCE = 0x0004, // named pipe
            FILE_READ_EA = 0x0008,          // file & directory
            FILE_WRITE_EA = 0x0010,         // file & directory
            FILE_EXECUTE = 0x0020,          // file
            FILE_TRAVERSE = 0x0020,         // directory
            FILE_DELETE_CHILD = 0x0040,     // directory
            FILE_READ_ATTRIBUTES = 0x0080,      // all
            FILE_WRITE_ATTRIBUTES = 0x0100,     // all
    
            //
            // Generic Section
            //
    
            GenericRead = 0x80000000,
            GenericWrite = 0x40000000,
            GenericExecute = 0x20000000,
            GenericAll = 0x10000000,
    
            SPECIFIC_RIGHTS_ALL = 0x00FFFF,
            FILE_ALL_ACCESS =
            StandardRightsRequired |
            Synchronize |
            0x1FF,
    
            FILE_GENERIC_READ =
            StandardRightsRead |
            FILE_READ_DATA |
            FILE_READ_ATTRIBUTES |
            FILE_READ_EA |
            Synchronize,
    
            FILE_GENERIC_WRITE =
            StandardRightsWrite |
            FILE_WRITE_DATA |
            FILE_WRITE_ATTRIBUTES |
            FILE_WRITE_EA |
            FILE_APPEND_DATA |
            Synchronize,
    
            FILE_GENERIC_EXECUTE =
            StandardRightsExecute |
              FILE_READ_ATTRIBUTES |
              FILE_EXECUTE |
              Synchronize
        }
    
        [Flags]
        public enum EFileShare : uint
        {
            /// <summary>
            /// 
            /// </summary>
            None = 0x00000000,
            /// <summary>
            /// Enables subsequent open operations on an object to request read access. 
            /// Otherwise, other processes cannot open the object if they request read access. 
            /// If this flag is not specified, but the object has been opened for read access, the function fails.
            /// </summary>
            Read = 0x00000001,
            /// <summary>
            /// Enables subsequent open operations on an object to request write access. 
            /// Otherwise, other processes cannot open the object if they request write access. 
            /// If this flag is not specified, but the object has been opened for write access, the function fails.
            /// </summary>
            Write = 0x00000002,
            /// <summary>
            /// Enables subsequent open operations on an object to request delete access. 
            /// Otherwise, other processes cannot open the object if they request delete access.
            /// If this flag is not specified, but the object has been opened for delete access, the function fails.
            /// </summary>
            Delete = 0x00000004
        }
    
        public enum ECreationDisposition : uint
        {
            /// <summary>
            /// Creates a new file. The function fails if a specified file exists.
            /// </summary>
            New = 1,
            /// <summary>
            /// Creates a new file, always. 
            /// If a file exists, the function overwrites the file, clears the existing attributes, combines the specified file attributes, 
            /// and flags with FILE_ATTRIBUTE_ARCHIVE, but does not set the security descriptor that the SECURITY_ATTRIBUTES structure specifies.
            /// </summary>
            CreateAlways = 2,
            /// <summary>
            /// Opens a file. The function fails if the file does not exist. 
            /// </summary>
            OpenExisting = 3,
            /// <summary>
            /// Opens a file, always. 
            /// If a file does not exist, the function creates a file as if dwCreationDisposition is CREATE_NEW.
            /// </summary>
            OpenAlways = 4,
            /// <summary>
            /// Opens a file and truncates it so that its size is 0 (zero) bytes. The function fails if the file does not exist.
            /// The calling process must open the file with the GENERIC_WRITE access right. 
            /// </summary>
            TruncateExisting = 5
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
    
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern SafeFileHandle CreateFile(
            string lpFileName,
            EFileAccess dwDesiredAccess,
            EFileShare dwShareMode,
            IntPtr lpSecurityAttributes,
            ECreationDisposition dwCreationDisposition,
            EFileAttributes dwFlagsAndAttributes,
            IntPtr hTemplateFile
        );
    
        [Flags]
        public enum FileMapProtection : uint
        {
            PageReadonly = 0x02,
            PageReadWrite = 0x04,
            PageWriteCopy = 0x08,
            PageExecuteRead = 0x20,
            PageExecuteReadWrite = 0x40,
            SectionCommit = 0x8000000,
            SectionImage = 0x1000000,
            SectionNoCache = 0x10000000,
            SectionReserve = 0x4000000,
        }
    
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern SafeFileHandle CreateFileMapping(
            SafeFileHandle hFile,
            IntPtr lpFileMappingAttributes,
            FileMapProtection flProtect,
            uint dwMaximumSizeHigh,
            uint dwMaximumSizeLow,
            string lpName
        );
    
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern SafeFileHandle CreateFileMapping(
            SafeFileHandle hFile,
            IntPtr lpFileMappingAttributes,
            FileMapProtection flProtect,
            uint dwMaximumSizeHigh,
            uint dwMaximumSizeLow,
            IntPtr lpName
        );
    
        [Flags]
        public enum FileMapAccess : uint
        {
            FileMapCopy = 0x0001,
            FileMapWrite = 0x0002,
            FileMapRead = 0x0004,
            FileMapAllAccess = 0x001f,
            FileMapExecute = 0x0020,
        }
    
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr MapViewOfFile(
            SafeFileHandle hFileMappingObject,
            FileMapAccess dwDesiredAccess,
            UInt32 dwFileOffsetHigh,
            UInt32 dwFileOffsetLow,
            UIntPtr dwNumberOfBytesToMap
        );
    
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool UnmapViewOfFile(IntPtr lpBaseAddress);
    
        [StructLayout(LayoutKind.Sequential)]
        public struct IMAGE_FILE_HEADER
        {
            public UInt16 Machine;
            public UInt16 NumberOfSections;
            public UInt32 TimeDateStamp;
            public UInt32 PointerToSymbolTable;
            public UInt32 NumberOfSymbols;
            public UInt16 SizeOfOptionalHeader;
            public UInt16 Characteristics;
        }
    
        [StructLayout(LayoutKind.Sequential)]
        public struct IMAGE_DATA_DIRECTORY
        {
            public UInt32 VirtualAddress;
            public UInt32 Size;
        }
    
        [StructLayout(LayoutKind.Sequential)]
        public struct IMAGE_OPTIONAL_HEADER
        {
            public UInt16 Magic;
            public Byte MajorLinkerVersion;
            public Byte MinorLinkerVersion;
            public UInt32 SizeOfCode;
            public UInt32 SizeOfInitializedData;
            public UInt32 SizeOfUninitializedData;
            public UInt32 AddressOfEntryPoint;
            public UInt32 BaseOfCode;
            public UInt32 BaseOfData;
            public UInt32 ImageBase;
            public UInt32 SectionAlignment;
            public UInt32 FileAlignment;
            public UInt16 MajorOperatingSystemVersion;
            public UInt16 MinorOperatingSystemVersion;
            public UInt16 MajorImageVersion;
            public UInt16 MinorImageVersion;
            public UInt16 MajorSubsystemVersion;
            public UInt16 MinorSubsystemVersion;
            public UInt32 Win32VersionValue;
            public UInt32 SizeOfImage;
            public UInt32 SizeOfHeaders;
            public UInt32 CheckSum;
            public UInt16 Subsystem;
            public UInt16 DllCharacteristics;
            public UInt32 SizeOfStackReserve;
            public UInt32 SizeOfStackCommit;
            public UInt32 SizeOfHeapReserve;
            public UInt32 SizeOfHeapCommit;
            public UInt32 LoaderFlags;
            public UInt32 NumberOfRvaAndSizes;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public IMAGE_DATA_DIRECTORY[] DataDirectory;
        }
    
        [StructLayout(LayoutKind.Sequential)]
        public struct IMAGE_NT_HEADERS
        {
            public UInt32 Signature;
            public IMAGE_FILE_HEADER FileHeader;
            public IMAGE_OPTIONAL_HEADER OptionalHeader;
        }
    
        [DllImport("dbghelp.dll", SetLastError = true)]
        public static extern IntPtr ImageNtHeader(
            IntPtr ImageBase
        );
    
        [StructLayout(LayoutKind.Sequential)]
        public struct IMAGE_EXPORT_DIRECTORY
        {
            public UInt32 Characteristics;
            public UInt32 TimeDateStamp;
            public UInt16 MajorVersion;
            public UInt16 MinorVersion;
            public UInt32 Name;
            public UInt32 Base;
            public UInt32 NumberOfFunctions;
            public UInt32 NumberOfNames;
            public UInt32 AddressOfFunctions;     // RVA from base of image
            public UInt32 AddressOfNames;     // RVA from base of image
            public UInt32 AddressOfNameOrdinals;  // RVA from base of image
        }
    
        [DllImport("dbghelp.dll", SetLastError = true)]
        public static extern IntPtr ImageRvaToVa(
            IntPtr NtHeaders,
            IntPtr Base,
            UInt32 Rva,
            IntPtr LastRvaSection
        );
    }
    
    namespace ConsoleApplication1
    {
        class Program
        {
            private static string[] GetExports(string ModuleFileName)
            {
                SafeFileHandle FileHandle = NativeMethods.CreateFile(
                    ModuleFileName,
                    NativeMethods.EFileAccess.GenericRead,
                    NativeMethods.EFileShare.Read,
                    IntPtr.Zero,
                    NativeMethods.ECreationDisposition.OpenExisting,
                    NativeMethods.EFileAttributes.Normal,
                    IntPtr.Zero
                );
                if (FileHandle.IsInvalid)
                    throw new Win32Exception();
    
                try
                {
                    SafeFileHandle ImageHandle = NativeMethods.CreateFileMapping(
                        FileHandle,
                        IntPtr.Zero,
                        NativeMethods.FileMapProtection.PageReadonly,
                        0,
                        0,
                        IntPtr.Zero
                    );
                    if (ImageHandle.IsInvalid)
                        throw new Win32Exception();
    
                    try
                    {
                        IntPtr ImagePointer = NativeMethods.MapViewOfFile(
                            ImageHandle,
                            NativeMethods.FileMapAccess.FileMapRead,
                            0,
                            0,
                            UIntPtr.Zero
                        );
                        if (ImagePointer == IntPtr.Zero)
                            throw new Win32Exception();
    
                        try
                        {
                            IntPtr HeaderPointer = NativeMethods.ImageNtHeader(ImagePointer);
                            if (HeaderPointer == IntPtr.Zero)
                                throw new Win32Exception();
    
                            NativeMethods.IMAGE_NT_HEADERS Header = (NativeMethods.IMAGE_NT_HEADERS)Marshal.PtrToStructure(
                                HeaderPointer,
                                typeof(NativeMethods.IMAGE_NT_HEADERS)
                            );
                            if (Header.Signature != 0x00004550)// "PE\0\0" as a DWORD
                                throw new Exception(ModuleFileName + " is not a valid PE file");
    
                            IntPtr ExportTablePointer = NativeMethods.ImageRvaToVa(
                                HeaderPointer,
                                ImagePointer,
                                Header.OptionalHeader.DataDirectory[0].VirtualAddress,
                                IntPtr.Zero
                            );
                            if (ExportTablePointer == IntPtr.Zero)
                                throw new Win32Exception();
                            NativeMethods.IMAGE_EXPORT_DIRECTORY ExportTable = (NativeMethods.IMAGE_EXPORT_DIRECTORY)Marshal.PtrToStructure(
                                ExportTablePointer,
                                typeof(NativeMethods.IMAGE_EXPORT_DIRECTORY)
                            );
    
                            IntPtr NamesPointer = NativeMethods.ImageRvaToVa(
                                HeaderPointer,
                                ImagePointer,
                                ExportTable.AddressOfNames,
                                IntPtr.Zero
                            );
                            if (NamesPointer == IntPtr.Zero)
                                throw new Win32Exception();
    
                            NamesPointer = NativeMethods.ImageRvaToVa(
                                HeaderPointer,
                                ImagePointer,
                                (UInt32)Marshal.ReadInt32(NamesPointer),
                                IntPtr.Zero
                            );
                            if (NamesPointer == IntPtr.Zero)
                                throw new Win32Exception();
    
                            string[] exports = new string[ExportTable.NumberOfNames];
                            for (int i = 0; i < exports.Length; i++)
                            {
                                exports[i] = Marshal.PtrToStringAnsi(NamesPointer);
                                NamesPointer += exports[i].Length + 1;
                            }
    
                            return exports;
                        }
                        finally
                        {
                            if (!NativeMethods.UnmapViewOfFile(ImagePointer))
                                throw new Win32Exception();
                        }
                    }
                    finally
                    {
                        ImageHandle.Close();
                    }
                }
                finally
                {
                    FileHandle.Close();
                }
            }
    
            static void Main(string[] args)
            {
                foreach (string s in GetExports(@"C:\Windows\System32\kernel32.dll"))
                {
                    Console.WriteLine(s);
                }
                Console.ReadLine();
            }
        }
    }
    
    
