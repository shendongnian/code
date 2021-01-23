        [DllImport("kernel32.dll")]
        internal static extern void GetNativeSystemInfo(ref SystemInfo lpSystemInfo);
        [DllImport("kernel32.dll")]
        internal static extern void GetSystemInfo(ref SystemInfo lpSystemInfo);
        [StructLayout(LayoutKind.Sequential)]
        internal struct SystemInfo
        {
            public ushort wProcessorArchitecture;
            public ushort wReserved;
            public uint dwPageSize;
            public IntPtr lpMinimumApplicationAddress;
            public IntPtr lpMaximumApplicationAddress;
            public UIntPtr dwActiveProcessorMask;
            public uint dwNumberOfProcessors;
            public uint dwProcessorType;
            public uint dwAllocationGranularity;
            public ushort wProcessorLevel;
            public ushort wProcessorRevision;
        }
        internal const ushort ProcessorArchitectureIntel = 0;
        internal const ushort ProcessorArchitectureIa64 = 6;
        internal const ushort ProcessorArchitectureAmd64 = 9;
        internal const ushort ProcessorArchitectureUnknown = 0xFFFF;
