    [StructLayoutAttribute(Sequential, CharSet = CharSet.Ansi)]
    public struct XYZ
    {
       public System.IntPtr rva;
       [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
       public string fn;
       public uint l;
       public uint o;
    }
