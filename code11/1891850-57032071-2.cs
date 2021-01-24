            [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern IntPtr CreateJobObject(IntPtr lpJobAttributes, string lpName);
    
            [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern bool SetInformationJobObject(IntPtr hJob, JOBOBJECTINFOCLASS JobObjectInfoClass, IntPtr lpJobObjectInfo, uint cbJobObjectInfoLength);
    
            [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern bool AssignProcessToJobObject(IntPtr hJob, IntPtr hProcess);
    
            [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern bool CloseHandle(IntPtr hObject);
    
            [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern bool QueryInformationJobObject(IntPtr hJob, JOBOBJECTINFOCLASS JobObjectInformationClass, [Out, MarshalAs(UnmanagedType.SysUInt)] IntPtr lpJobObjectInformation, int cbJobObjectInformationLength, out int lpReturnLength);
    
            [StructLayout(LayoutKind.Sequential)]
            struct JOBOBJECT_BASIC_LIMIT_INFORMATION
            {
                public ulong PerProcessUserTimeLimit;
                public ulong PerJobUserTimeLimit;
                public int LimitFlags;
                public IntPtr MinimumWorkingSetSize;
                public IntPtr MaximumWorkingSetSize;
                public int ActiveProcessLimit;
                public IntPtr Affinity;
                public int PriorityClass;
                public int SchedulingClass;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            struct IO_COUNTERS
            {
                public ulong ReadOperationCount;
                public ulong WriteOperationCount;
                public ulong OtherOperationCount;
                public ulong ReadTransferCount;
                public ulong WriteTransferCount;
                public ulong OtherTransferCount;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            struct JOBOBJECT_EXTENDED_LIMIT_INFORMATION
            {
                public JOBOBJECT_BASIC_LIMIT_INFORMATION BasicLimitInformation;
                public IO_COUNTERS IoInfo;
                public IntPtr ProcessMemoryLimit;
                public IntPtr JobMemoryLimit;
                public IntPtr PeakProcessMemoryUsed;
                public IntPtr PeakJobMemoryUsed;
            }
    
            //
            // Basic Limits
            //
            public const int JOB_OBJECT_LIMIT_WORKINGSET = 0x00000001;
            public const int JOB_OBJECT_LIMIT_PROCESS_TIME = 0x00000002;
            public const int JOB_OBJECT_LIMIT_JOB_TIME = 0x00000004;
            public const int JOB_OBJECT_LIMIT_ACTIVE_PROCESS = 0x00000008;
            public const int JOB_OBJECT_LIMIT_AFFINITY = 0x00000010;
            public const int JOB_OBJECT_LIMIT_PRIORITY_CLASS = 0x00000020;
            public const int JOB_OBJECT_LIMIT_PRESERVE_JOB_TIME = 0x00000040;
            public const int JOB_OBJECT_LIMIT_SCHEDULING_CLASS = 0x00000080;
    
            //
            // Extended Limits
            //
            public const int JOB_OBJECT_LIMIT_PROCESS_MEMORY = 0x00000100;
            public const int JOB_OBJECT_LIMIT_JOB_MEMORY = 0x00000200;
            public const int JOB_OBJECT_LIMIT_JOB_MEMORY_HIGH = JOB_OBJECT_LIMIT_JOB_MEMORY;
            public const int JOB_OBJECT_LIMIT_DIE_ON_UNHANDLED_EXCEPTION = 0x00000400;
            public const int JOB_OBJECT_LIMIT_BREAKAWAY_OK = 0x00000800;
            public const int JOB_OBJECT_LIMIT_SILENT_BREAKAWAY_OK = 0x00001000;
            public const int JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE = 0x00002000;
            public const int JOB_OBJECT_LIMIT_SUBSET_AFFINITY = 0x00004000;
            public const int JOB_OBJECT_LIMIT_JOB_MEMORY_LOW = 0x00008000;
    
            public enum JOBOBJECTINFOCLASS
            {
                JobObjectBasicAccountingInformation = 1,
                JobObjectBasicLimitInformation,
                JobObjectBasicProcessIdList,
                JobObjectBasicUIRestrictions,
                JobObjectSecurityLimitInformation,  // deprecated
                JobObjectEndOfJobTimeInformation,
                JobObjectAssociateCompletionPortInformation,
                JobObjectBasicAndIoAccountingInformation,
                JobObjectExtendedLimitInformation,
                JobObjectJobSetInformation,
                JobObjectGroupInformation,
                JobObjectNotificationLimitInformation,
                JobObjectLimitViolationInformation,
                JobObjectGroupInformationEx,
                JobObjectCpuRateControlInformation,
                JobObjectCompletionFilter,
                JobObjectCompletionCounter,
                JobObjectReserved1Information = 18,
                JobObjectReserved2Information,
                JobObjectReserved3Information,
                JobObjectReserved4Information,
                JobObjectReserved5Information,
                JobObjectReserved6Information,
                JobObjectReserved7Information,
                JobObjectReserved8Information,
                JobObjectReserved9Information,
                JobObjectReserved10Information,
                JobObjectReserved11Information,
                JobObjectReserved12Information,
                JobObjectReserved13Information,
                JobObjectReserved14Information = 31,
                JobObjectNetRateControlInformation,
                JobObjectNotificationLimitInformation2,
                JobObjectLimitViolationInformation2,
                JobObjectCreateSilo,
                JobObjectSiloBasicInformation,
                JobObjectReserved15Information = 37,
                JobObjectReserved16Information,
                JobObjectReserved17Information,
                JobObjectReserved18Information,
                JobObjectReserved19Information = 41,
                JobObjectReserved20Information,
                MaxJobObjectInfoClass
            }
  
