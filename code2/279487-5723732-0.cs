[DllImport(EntryPoint="ExternalMethod"]
private static void ExternalMethodInvoke(
[MarshalAs(UnmanagedType.SysInt), In] IntPtr);
public void ManagedWrapper(ref double[] array)
{
    IntPtr unmanagedMem = Marshal.AllocHGlobal(1000);
    Marshal.Copy(array, unmanagedMem, 0, 1000);
    ExternalMethodInvoke(unmanagedMem); // use try finally for freeing
    Marshal.Copy(unmanagedMem, array, 1, 1000);
    Marshal.FreeHGlobal(unmanagedMem);
}
