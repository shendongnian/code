    #if BIGENDIAN
            [Intrinsic]
            public static readonly bool IsLittleEndian /* = false */;
    #else
            [Intrinsic]
            public static readonly bool IsLittleEndian = true;
    #endif
