    public static T BytesToStruct<T>(byte[] bytes) where T : struct
    {
        AssertUtilities.ArgumentNotNull(bytes, "bytes");
        var structSize = Marshal.SizeOf(typeof(T));
        var pointer = IntPtr.Zero;
        try
        {
            pointer = Marshal.AllocHGlobal(structSize);
            Marshal.Copy(bytes, 0, pointer, structSize);
            return (T)Marshal.PtrToStructure(pointer, typeof(T));
        }
        finally
        {
            if (pointer != IntPtr.Zero)
                Marshal.FreeHGlobal(pointer);
        }
    }
    public static byte[] StructToBytes<T>(T structObject) where T : struct
    {
        var structSize = Marshal.SizeOf(typeof(T));
        var bytes = new byte[structSize];
        var pointer = IntPtr.Zero;
        try
        {
            pointer = Marshal.AllocHGlobal(structSize);
            Marshal.StructureToPtr(structObject, pointer, true);
            Marshal.Copy(pointer, bytes, 0, structSize);
            return bytes;
        }
        finally
        {
            if (pointer != IntPtr.Zero)
                Marshal.FreeHGlobal(pointer);
        }
    }
