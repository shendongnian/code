    /// <summary>
    /// Converts the supplied object to a byte array.
    /// </summary>
    public static byte[] ToByteArray(object obj)
    {
        int len = Marshal.SizeOf(obj);
        byte[] arr = new byte[len];
        IntPtr ptr = Marshal.AllocHGlobal(len);
        Marshal.StructureToPtr(obj, ptr, true);
        Marshal.Copy(ptr, arr, 0, len);
        Marshal.FreeHGlobal(ptr);
        return arr;
    }
    /// <summary>
    /// Maps the supplied byte array onto a structure of the specified type.
    /// </summary>
    public static T ToStructure<T>(byte[] byteArray)
    {
        GCHandle h = GCHandle.Alloc(byteArray, GCHandleType.Pinned);
        T result = (T)Marshal.PtrToStructure(h.AddrOfPinnedObject(), typeof(T));
        h.Free();
        return result;
    }
