            // This field indicates the "endianess" of the architecture.
            // The value is set to true if the architecture is
            // little endian; false if it is big endian.
    #if BIGENDIAN
            public static readonly bool IsLittleEndian /* = false */;
    #else
            public static readonly bool IsLittleEndian = true;
    #endif
