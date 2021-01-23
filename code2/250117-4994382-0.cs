    public static string Get(object a)
    {
        GCHandle handle = GCHandle.Alloc(a, GCHandleType.Pinned);
        try
        {
            IntPtr pointer = GCHandle.ToIntPtr(handle);
            return "0x" + pointer.ToString("X");
        }
        finally
        {
            handle.Free();
        }
    }
