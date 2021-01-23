    [Flags]
    public enum MyFlags
    {
        None = 0,
        A    = 0x1,
        B    = 0x2,
    }
    public static class MyFlagsExt
    {
        public static MyFlags A(this MyFlags myFlags)
        {
            return myFlags | MyFlags.A;
        }
        public static MyFlags B(this MyFlags myFlags)
        {
            return myFlags | MyFlags.B;
        }
    }
    ...
    
    var flags = MyFlags.A.B();
