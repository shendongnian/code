    [StructLayout(LayoutKind.Explicit)]
    public struct EventHeader
    {
        [FieldOffset(0)]
        public ushort Size;
        [FieldOffset(2)]
        public ushort HeaderType;
        [FieldOffset(4)]
        public ushort Flags;
        [FieldOffset(6)]
        public ushort EventProperty;
        [FieldOffset(8)]
        public uint ThreadId;
        [FieldOffset(12)]
        public uint ProcessId;
        [FieldOffset(16)]
        public LargeInteger TimeStamp;
        [FieldOffset(24)]
        public Guid ProviderId;
        [FieldOffset(40)]
        public Guid EventDescriptor;
        [FieldOffset(52)]
        public uint KernelTime;
        [FieldOffset(56)]
        public uint UserTime;
        [FieldOffset(52)]
        public ulong ProcessorTime;
        [FieldOffset(60)]
        public Guid ActivityId;
    }
