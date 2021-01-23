    [DllImport(_dllname, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern bool fastSegment(IntPtr img, int width, int height);
    [ReliabilityContract(Consistency.MayCorruptProcess, Cer.None)]
    static void FastSegment(byte[] data, int width, int height)
    {
        var length = width * height;
        var ptr = Marshal.AllocHGlobal(width * height);
        try
        {
            Marshal.Copy(data, 0, ptr, length);
            fastSegment(ptr, width, height);
            Marshal.Copy(ptr, data, 0, length);
        }
        finally
        {
            Marshal.FreeHGlobal(ptr);
        }
    }
    // ---- OR ----
    [DllImport(_dllname, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern bool fastSegment(IntPtr img, int width, int height);
    [ReliabilityContract(Consistency.MayCorruptProcess, Cer.None)]
    static void FastSegment(byte[] data, int width, int height)
    {
        var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
        try
        {
            fastSegment(handle.AddrOfPinnedObject(), width, height);
        }
        finally
        {
            handle.Free();
        }
    }
    // ---- OR ----
    [DllImport(_dllname, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static unsafe extern bool fastSegment(byte* img, int width, int height);
    [ReliabilityContract(Consistency.MayCorruptProcess, Cer.None)]
    static void FastSegment(byte[] data, int width, int height)
    {
        unsafe
        {
            fixed (byte* dataPinned = data)
            {
                fastSegment(dataPinned, width, height);
            }
        }
    }
