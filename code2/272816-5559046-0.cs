    internal static class UnsafeNativeMethods
    {
    const string _dllLocation = "CoreDLL.dll";
    [DllImport(_dllLocation), CallingConvention=CallingConvention.Cdecl]
    public static extern void GetResult(double resultLine);
    }
