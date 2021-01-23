    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    struct Foo
    {
        public int id;
        //[MarshalAs(UnmanagedType.BStr)]
        //public string A;
        //[MarshalAs(UnmanagedType.BStr)]
        //public string B;
    }
    static void Main(string[] args)
    {
        byte[] bits = new byte[] {
            0x00, 0x00, 
            0x01, 0x00, 
            0x00, 0x00, 
            0x08, 0x00,     // Length prefix?               
            0x4F, 0x00,     // Start OFIR?
            0x46, 0x00, 
            0x49, 0x00,     
            0x52, 0x00,     
            0x00, 0x00, 
            0x08, 0x00,     // Length prefix?
            0x4F, 0x00,     // Start OFIR?
            0x46, 0x00, 
            0x49, 0x00, 
            0x52, 0x00 };   
        GCHandle pinnedPacket = GCHandle.Alloc(bits, GCHandleType.Pinned);
        Foo msg = (Foo)Marshal.PtrToStructure(
            pinnedPacket.AddrOfPinnedObject(),
            typeof(Foo));
        pinnedPacket.Free();
    }
