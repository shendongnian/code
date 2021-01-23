    [DllImport(@"MyDll.dll",
     CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr GetList(out int size);
    [DllImport(@"MyDll.dll",
     CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
    private static extern void RemoveList(IntPtr array);
    public static int[] GetList()
    {
        int[] result = null;
        int size;
        IntPtr arrayValue = IntPtr.Zero;
        try
        {
            arrayValue = GetList(out size);
            if (arrayValue != IntPtr.Zero)
            {
                result = new int[size];
                Marshal.Copy(arrayValue, result, 0, size);
            }
        }
        finally
        {
            // don't forget to free the list
            RemoveList(arrayValue);
        }
        return result;
    }
