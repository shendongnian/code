    [StructLayout(LayoutKind.Sequential, Pack=2)]
    public struct BITMAPFILEHEADER
    {
         public ushort bfType; 
         public uint bfSize; 
         public ushort bfReserved1; 
         public ushort bfReserved2; 
         public uint bfOffBits; 
    }
