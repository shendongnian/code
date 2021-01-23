    private static class NativeMethods
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool SetDllDirectory(string pathName);
    }
    ... 
        // Underlying SQLite libraries are native. 
        // Manually load the correct library depending on the architecture.
        var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Native");
        if(IntPtr.Size == 8) // or: if(Environment.Is64BitProcess) // .NET 4.0
        {
            path = Path.Combine(path, "X64");
        }
        else
        {
            // X32
            path = Path.Combine(path, "X86");
        }
        NativeMethods.SetDllDirectory(path);
