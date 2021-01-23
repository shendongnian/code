    [DllImport(@"test.dll")]
    public static extern IntPtr AllocateIntArray(int N);
    [DllImport(@"test.dll")]
    public static extern void FreeMemory(IntPtr ptr);
    static void Main(string[] args)
    {
        IntPtr ptr = AllocateIntArray(5);
        //...do something with the memory
        FreeMemory(ptr);
    }
