    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DeviceStatus
    {
        public UInt16 position;    // Byte 0 and 1
        public Byte counter;       // Byte 2
        public Fruit currentFruit; // Byte 3
    };
    enum Fruit : Byte
    {
        Off = 0,
        Apple = 1,
        Orange = 2,
        Banana = 3,
    }
