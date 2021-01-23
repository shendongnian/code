    [DllImport("kernel32.dll")]
    static extern ErrorModes  SetErrorMode(ErrorModes uMode);
    [Flags]
    public enum ErrorModes : uint {
        SYSTEM_DEFAULT             = 0x0,
        SEM_FAILCRITICALERRORS     = 0x0001,
        SEM_NOALIGNMENTFAULTEXCEPT = 0x0004,
        SEM_NOGPFAULTERRORBOX      = 0x0002,
        SEM_NOOPENFILEERRORBOX     = 0x8000
    }
