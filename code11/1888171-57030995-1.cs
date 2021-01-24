		[StructLayout(LayoutKind.Explicit, Pack = 16)]
        public struct CONTEXT64
        {
            [FieldOffset(0x000)]
            public ulong P1Home;
            [FieldOffset(0x008)]
            public ulong P2Home;
            [FieldOffset(0x010)]
            public ulong P3Home;
            [FieldOffset(0x018)]
            public ulong P4Home;
            [FieldOffset(0x020)]
            public ulong P5Home;
            [FieldOffset(0x028)]
            public ulong P6Home;
            [FieldOffset(0x030)]
            public int ContextFlags;
            [FieldOffset(0x034)]
            public int MxCsr;
            [FieldOffset(0x038)]
            public ushort SegCs;
            [FieldOffset(0x03a)]
            public ushort SegDs;
            [FieldOffset(0x03c)]
            public ushort SegEs;
            [FieldOffset(0x03e)]
            public ushort SegFs;
            [FieldOffset(0x040)]
            public ushort SegGs;
            [FieldOffset(0x042)]
            public ushort SegSs;
            [FieldOffset(0x044)]
            public int EFlags;
            [FieldOffset(0x048)]
            public ulong Dr0;
            [FieldOffset(0x050)]
            public ulong Dr1;
            [FieldOffset(0x058)]
            public ulong Dr2;
            [FieldOffset(0x060)]
            public ulong Dr3;
            [FieldOffset(0x068)]
            public ulong Dr6;
            [FieldOffset(0x070)]
            public ulong Dr7;
            [FieldOffset(0x078)]
            public ulong Rax;
            [FieldOffset(0x080)]
            public ulong Rcx;
            [FieldOffset(0x088)]
            public ulong Rdx;
            [FieldOffset(0x090)]
            public ulong Rbx;
            [FieldOffset(0x098)]
            public ulong Rsp;
            [FieldOffset(0x0a0)]
            public ulong Rbp;
            [FieldOffset(0x0a8)]
            public ulong Rsi;
            [FieldOffset(0x0b0)]
            public ulong Rdi;
            [FieldOffset(0x0b8)]
            public ulong R8;
            [FieldOffset(0x0c0)]
            public ulong R9;
            [FieldOffset(0x0c8)]
            public ulong R10;
            [FieldOffset(0x0d0)]
            public ulong R11;
            [FieldOffset(0x0d8)]
            public ulong R12;
            [FieldOffset(0x0e0)]
            public ulong R13;
            [FieldOffset(0x0e8)]
            public ulong R14;
            [FieldOffset(0x0f0)]
            public ulong R15;
            [FieldOffset(0x0f8)]
            public ulong Rip;
            [FieldOffset(0x100)]
            //[MarshalAs(UnmanagedType.Struct, SizeConst = 512)]
            public XMM_SAVE_AREA32 FltSave;
            [FieldOffset(0x300)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 26)]
            public M128A[] VectorRegister;
            [FieldOffset(0x4a0)]
            public ulong VectorControl;
            [FieldOffset(0x4a8)]
            public ulong DebugControl;
            [FieldOffset(0x4b0)]
            public ulong LastBranchToRip;
            [FieldOffset(0x4b8)]
            public ulong LastBranchFromRip;
            [FieldOffset(0x4c0)]
            public ulong LastExceptionToRip;
            [FieldOffset(0x4c8)]
            public ulong LastExceptionFromRip;
        }
		[StructLayout(LayoutKind.Sequential, Pack = 16)]
        public struct XMM_SAVE_AREA32
        {
            public ushort ControlWord;
            public ushort StatusWord;
            public char TagWord;
            public char Reserved1;
            public ushort ErrorOpcode;
            public uint ErrorOffset;
            public ushort ErrorSelector;
            public ushort Reserved2;
            public uint DataOffset;
            public ushort DataSelector;
            public ushort Reserved3;
            public uint MxCsr;
            public uint MxCsrMask;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public M128A[] FloatRegisters;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public M128A[] XmmRegisters;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 96)]
            public char[] Reserved4;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public struct FLOATING_SAVE_AREA
        {
            public int ControlWord;
            public int StatusWord;
            public int TagWord;
            public int ErrorOffset;
            public int ErrorSelector;
            public int DataOffset;
            public int DataSelector;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = SIZE_OF_80387_REGISTERS)]
            public byte[] RegisterArea;
            public int Spare0;
        }
        public const int MAXIMUM_SUPPORTED_EXTENSION = 512;
        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct CONTEXT
        {
            public int ContextFlags;
            public int Dr0;
            public int Dr1;
            public int Dr2;
            public int Dr3;
            public int Dr6;
            public int Dr7;
            public FLOATING_SAVE_AREA FloatSave;
            public int SegGs;
            public int SegFs;
            public int SegEs;
            public int SegDs;
            public int Edi;
            public int Esi;
            public int Ebx;
            public int Edx;
            public int Ecx;
            public int Eax;
            public int Ebp;
            public int Eip;
            public int SegCs;              // MUST BE SANITIZED
            public int EFlags;             // MUST BE SANITIZED
            public int Esp;
            public int SegSs;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAXIMUM_SUPPORTED_EXTENSION)]
            public byte[] ExtendedRegisters;
        }
        
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr GetCurrentThread();
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool GetThreadContext(IntPtr hThread, ref CONTEXT lpContext);
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool GetThreadContext(IntPtr hThread, ref CONTEXT64 lpContext);
        public const int SIZE_OF_80387_REGISTERS = 80;
        public const int CONTEXT_i386 = 0x00010000;    // this assumes that i386 and
        public const int CONTEXT_i486 = 0x00010000;    // i486 have identical context records
        public const int CONTEXT_CONTROL = (CONTEXT_i386 | 0x00000001); // SS:SP, CS:IP, FLAGS, BP
        public const int CONTEXT_INTEGER = (CONTEXT_i386 | 0x00000002); // AX, BX, CX, DX, SI, DI
        public const int CONTEXT_SEGMENTS = (CONTEXT_i386 | 0x00000004); // DS, ES, FS, GS
        public const int CONTEXT_FLOATING_POINT = (CONTEXT_i386 | 0x00000008); // 387 state
        public const int CONTEXT_DEBUG_REGISTERS = (CONTEXT_i386 | 0x00000010); // DB 0-3,6,7
        public const int CONTEXT_EXTENDED_REGISTERS = (CONTEXT_i386 | 0x00000020); // cpu specific extensions
        public const int CONTEXT_FULL = (CONTEXT_CONTROL | CONTEXT_INTEGER | CONTEXT_SEGMENTS);
        public const int CONTEXT_ALL = (CONTEXT_CONTROL | CONTEXT_INTEGER | CONTEXT_SEGMENTS | CONTEXT_FLOATING_POINT | CONTEXT_DEBUG_REGISTERS | CONTEXT_EXTENDED_REGISTERS);
        public const int CONTEXT_XSTATE = (CONTEXT_i386 | 0x00000040);
        public const int CONTEXT_EXCEPTION_ACTIVE = 0x08000000;
        public const int CONTEXT_SERVICE_ACTIVE = 0x10000000;
        public const int CONTEXT_EXCEPTION_REQUEST = 0x40000000;
        public const int CONTEXT_EXCEPTION_REPORTING = unchecked((int)0x80000000);
 
