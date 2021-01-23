    [DllImport(EntryPoint="ExternalMethod"]
    private static void ExternalMethodInvoke(
        [MarshalAs(UnmanagedType.SysInt), Out] out IntPtr);
    [DllImport(EntryPoint="ExternalDeleteArray"]
    private static void ExternalDeleteArrayInvoke(
        [MarshalAs(UnmanagedType.SysInt), Out] out IntPtr);
    public void ManagedWrapper(ref double[] array)
    {
        IntPtr unmanagedMem;
        ExternalMethodInvoke(out unmanagedMem); // use try finally for freeing
        Marshal.Copy(unmanagedMem, array, 1, 1000);
        ExternalDeleteArrayInvoke(unmanagedMem);
    }
