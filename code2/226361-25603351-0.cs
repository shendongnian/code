    [CompilerGenerated]
    internal class <PrivateImplementationDetails>
    {
        // Fields
        internal static $ArrayType$4 $$field-0; // data size: 4 bytes
        internal static $ArrayType$4 $$field-1; // data size: 4 bytes
        internal static $ArrayType$4 $$field-2; // data size: 4 bytes
        internal static $ArrayType$4 $$field-3; // data size: 4 bytes
        internal static $ArrayType$44 $$field-4; // data size: 44 bytes
        internal static $ArrayType$4 $$field-5; // data size: 4 bytes
    
        // Nested Types
        [StructLayout(LayoutKind.Explicit, Size=4, Pack=1)]
        private struct $ArrayType$4
        {
        }
    
        [StructLayout(LayoutKind.Explicit, Size=0x2c, Pack=1)]
        private struct $ArrayType$44
        {
        }
    }
----------
    static GATWavHelper()
    {
        riffBytes = new byte[] { 0x52, 0x49, 70, 70 };
        waveBytes = new byte[] { 0x57, 0x41, 0x56, 0x45 };
        fmtBytes = new byte[] { 0x66, 0x6d, 0x74, 0x20 };
        dataBytes = new byte[] { 100, 0x61, 0x74, 0x61 };
        headerSize = 0x2c;
        floatToInt16RescaleFactor = 0x7fff;
        __canonicalHeader = new byte[] { 
            0x52, 0x49, 70, 70, 0, 0, 0, 0, 0x57, 0x41, 0x56, 0x45, 0x66, 0x6d, 0x74, 0x20, 
            0, 0, 0, 0x10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 100, 0x61, 0x74, 0x61, 0, 0, 0, 0
         };
    }
