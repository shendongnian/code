    [StructLayout(LayoutKind.Sequential)]  
    public struct pio_desc 
    {
        public IntPtr pin_name;     // Leave at IntPtr.Zero
        public uint pin_number;     //4 bytes
        public uint default_value;  //4 bytes
        public byte attribute;      //1 byte
        public uint pio_type;       //4 bytes
    }
