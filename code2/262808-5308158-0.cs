    #if IA32
        using SysInt = System.Int32;
        using SysUInt = System.UInt32;
    #elif INTEL64
        using SysInt = System.Int64;
        using SysUInt = System.UInt64;
    #endif
